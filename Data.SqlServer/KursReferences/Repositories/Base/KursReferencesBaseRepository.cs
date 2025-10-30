using Common.Helper.Interfaces.Identity;
using Common.Repositories.Specification;
using Data.SqlServer.Extensions;
using Data.SqlServer.KursReferences.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.SqlServer.KursReferences.Repositories.Base;

public class KursReferencesBaseRepository<T>(IKursReferenceContextRepository contextRepository)
    : IKursReferencesBaseRepository<T> where T : class, IBaseIdentity
{
    protected readonly IKursReferenceContextRepository myContextRepository = contextRepository;

    public string GetDbName(Guid id)
    {
        return myContextRepository.GetContextName(id);
    }

    public async Task<IEnumerable<T>> FindAsync(Guid dbId, Specification<T> specification, CancellationToken cancelToken)
    {
        var ctx = myContextRepository.GetContext(dbId);
        if (ctx is null)
            throw new NullReferenceException("IKursReferenceContextRepository.FindAsync - контекст базы данных - null");
        return await ctx.ApplySpecification(specification).ToListAsync(cancelToken);
    }

    public virtual async Task CreateAsync(Guid dbId, T entity, CancellationToken cancelToken)
    {
        var ctx = myContextRepository.GetContext(dbId);
        if (dbId == Guid.Empty || ctx is null) throw new NullReferenceException($"Db countext '{dbId}' не найден");
        var id = entity.Id;


        switch (id)
        {
            case int i when i == 0:
                i = (int)await ctx.Set<T>().MaxAsync(_ => _.Id, cancelToken) + 1;
                entity.Id = i;
                break;
            case decimal d when d == 0:
                d = (decimal)await ctx.Set<T>().MaxAsync(_ => _.Id, cancelToken) + 1;
                entity.Id = d;
                break;
            case Guid g when g == Guid.Empty:
                entity.Id = Guid.NewGuid();
                break;
        }

        await ctx.Set<T>().AddAsync(entity, cancelToken);
        await ctx.SaveChangesAsync(cancelToken);
    }

    public async Task CreateManyAsync(Guid dbId, IEnumerable<T> entities, CancellationToken cancelToken)
    {
        var ctx = myContextRepository.GetContext(dbId);
        if (dbId == Guid.Empty || ctx is null) throw new NullReferenceException($"Db countext '{dbId}' не найден");
        var enumerable = entities.ToList();
        if (!enumerable.Any()) return;
        var sett = ctx.Set<T>();
        foreach (var ent in enumerable.ToList())
        {
            var id = ent.Id;
            switch (id)
            {
                case int i when i == 0:
                    i = (int)await ctx.Set<T>().MaxAsync(_ => _.Id, cancelToken) + 1;
                    ent.Id = i;
                    break;
                case decimal d when d == 0:
                    d = (decimal)await ctx.Set<T>().MaxAsync(_ => _.Id, cancelToken) + 1;
                    ent.Id = d;
                    break;
                case Guid g when g == Guid.Empty:
                    ent.Id = Guid.NewGuid();
                    break;
            }

            sett.Add(ent);
        }

        await ctx.SaveChangesAsync(cancelToken);
    }

    public virtual async Task UpdateAsync(Guid dbId, T entity, CancellationToken cancelToken)
    {
        var ctx = myContextRepository.GetContext(dbId);
        if (dbId == Guid.Empty || ctx is null) throw new NullReferenceException($"Db countext '{dbId}' не найден");

        ctx.Set<T>().Update(entity);
        await ctx.SaveChangesAsync(cancelToken);
    }

    public virtual async Task UpdateManyAsync(Guid dbId, IEnumerable<T> entities, CancellationToken cancelToken)
    {
        var ctx = myContextRepository.GetContext(dbId);
        if (dbId == Guid.Empty || ctx is null) throw new NullReferenceException($"Db countext '{dbId}' не найден");
        var enumerable = entities.ToList();
        if (!enumerable.Any()) return;
        var sett = ctx.Set<T>();
        foreach (var ent in enumerable.ToList()) sett.Update(ent);
        await ctx.SaveChangesAsync(cancelToken);
    }

    public async Task DeleteAsync(Guid dbId, IBaseIdentity id, CancellationToken cancelToken)
    {
        var ctx = myContextRepository.GetContext(dbId);
        if (dbId == Guid.Empty || ctx is null) throw new NullReferenceException($"Db countext '{dbId}' не найден");
        var old = await ctx.Set<T>().FindAsync(id.Id, cancelToken);
        if (old is not null)
        {
            ctx.Set<T>().Remove(old);
            await ctx.SaveChangesAsync(cancelToken);
        }
    }

    public async Task DeleteManyAsync(Guid dbId, IEnumerable<IBaseIdentity> ids, CancellationToken cancelToken)
    {
        var ctx = myContextRepository.GetContext(dbId);
        if (dbId == Guid.Empty || ctx is null) throw new NullReferenceException($"Db countext '{dbId}' не найден");
        var enumerable = ids.ToList();
        if (!enumerable.Any()) return;
        var sett = ctx.Set<T>();
        foreach (var id in enumerable)
        {
            var old = await sett.FindAsync(id.Id, cancelToken);
            if (old is not null)
                sett.Remove(old);
        }

        await ctx.SaveChangesAsync(cancelToken);
    }

    public async Task<T?> GetByIdAsync(Guid dbId, IBaseIdentity id, CancellationToken cancelToken)
    {
        var ctx = myContextRepository.GetContext(dbId);
        if (dbId == Guid.Empty || ctx is null) throw new NullReferenceException($"Db countext '{dbId}' не найден");
        return await ctx.Set<T>().FindAsync(id.Id, cancelToken);
    }

    public async Task<IEnumerable<T>> GetAllAsync(Guid dbId, CancellationToken cancelToken)
    {
        var ctx = myContextRepository.GetContext(dbId);
        if (dbId == Guid.Empty || ctx is null) throw new NullReferenceException($"Db countext '{dbId}' не найден");
        return await ctx.Set<T>().ToListAsync(cancelToken);
    }

    public async Task<IEnumerable<T>> GetListAsync(Guid dbId, List<IBaseIdentity> ids, CancellationToken cancelToken)
    {
        var ctx = myContextRepository.GetContext(dbId);
        if (dbId == Guid.Empty || ctx is null) throw new NullReferenceException($"Db context '{dbId}' не найден");

        var guidIds = new List<Guid>();
        var docCodes = new List<decimal>();
        var intIds = new List<int>();
        switch (ids.First().Id)
        {
            case Guid:
                guidIds.AddRange(ids.Select(id => (Guid)id.Id));
                return await ctx.Set<T>().Where(_ => guidIds.Contains((Guid)_.Id)).ToListAsync(cancelToken);
            case long dc:
                switch (dc)
                {
                    case < 1000000000:
                        intIds.AddRange(ids.Select(_ => _.Id).Select(Convert.ToInt32));
                        return await ctx.Set<T>().Where(_ => intIds.Contains((int)_.Id)).ToListAsync(cancelToken);
                    default:
                        docCodes.AddRange(ids.Select(_ => _.Id).Select(Convert.ToDecimal));
                        return await ctx.Set<T>().Where(_ => docCodes.Contains(((IDocCodeIdentity)_).DOC_CODE)).ToListAsync(cancelToken);
                }
        }
        throw new ArgumentException("Список ключей не верен");
    }
}
