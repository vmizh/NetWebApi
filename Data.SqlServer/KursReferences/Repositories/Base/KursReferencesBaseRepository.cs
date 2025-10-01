using Common.Helper.Interfaces.Identity;
using Data.SqlServer.KursReferences.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.SqlServer.KursReferences.Repositories.Base;

public class KursReferencesBaseRepository<T>(IKursReferenceContextRepository contextRepository)
    : IKursReferencesBaseRepository<T> where T : class, IBaseIdentity
{
    protected IKursReferenceContextRepository myContextRepository = contextRepository;

    public string GetDbName(Guid id)
    {
        return myContextRepository.GetContextName(id);
    }

    public virtual async Task CreateAsync(Guid dbId, T entity)
    {
        var ctx = myContextRepository.GetContext(dbId);
        if (dbId == Guid.Empty || ctx is null) throw new NullReferenceException($"Db countext '{dbId}' не найден");
        var id = entity.Id;


        switch (id)
        {
            case int i when i == 0:
                i = (int)await ctx.Set<T>().MaxAsync(_ => _.Id) + 1;
                entity.Id = i;
                break;
            case decimal d when d == 0:
                d = (decimal)await ctx.Set<T>().MaxAsync(_ => _.Id) + 1;
                entity.Id = d;
                break;
            case Guid g when g == Guid.Empty:
                entity.Id = Guid.NewGuid();
                break;
        }

        await ctx.Set<T>().AddAsync(entity);
        await ctx.SaveChangesAsync();
    }

    public async Task CreateManyAsync(Guid dbId, IEnumerable<T> entities)
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
                    i = (int)await ctx.Set<T>().MaxAsync(_ => _.Id) + 1;
                    ent.Id = i;
                    break;
                case decimal d when d == 0:
                    d = (decimal)await ctx.Set<T>().MaxAsync(_ => _.Id) + 1;
                    ent.Id = d;
                    break;
                case Guid g when g == Guid.Empty:
                    ent.Id = Guid.NewGuid();
                    break;
            }

            sett.Add(ent);
        }

        await ctx.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(Guid dbId, T entity)
    {
        var ctx = myContextRepository.GetContext(dbId);
        if (dbId == Guid.Empty || ctx is null) throw new NullReferenceException($"Db countext '{dbId}' не найден");

        ctx.Set<T>().Update(entity);
        await ctx.SaveChangesAsync();
    }

    public virtual async Task UpdateManyAsync(Guid dbId, IEnumerable<T> entities)
    {
        var ctx = myContextRepository.GetContext(dbId);
        if (dbId == Guid.Empty || ctx is null) throw new NullReferenceException($"Db countext '{dbId}' не найден");
        var enumerable = entities.ToList();
        if (!enumerable.Any()) return;
        var sett = ctx.Set<T>();
        foreach (var ent in enumerable.ToList()) sett.Update(ent);
        await ctx.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid dbId, IBaseIdentity id)
    {
        var ctx = myContextRepository.GetContext(dbId);
        if (dbId == Guid.Empty || ctx is null) throw new NullReferenceException($"Db countext '{dbId}' не найден");
        var old = await ctx.Set<T>().FindAsync(id.Id);
        if (old is not null)
        {
            ctx.Set<T>().Remove(old);
            await ctx.SaveChangesAsync();
        }
    }

    public async Task DeleteManyAsync(Guid dbId, IEnumerable<IBaseIdentity> ids)
    {
        var ctx = myContextRepository.GetContext(dbId);
        if (dbId == Guid.Empty || ctx is null) throw new NullReferenceException($"Db countext '{dbId}' не найден");
        var enumerable = ids.ToList();
        if (!enumerable.Any()) return;
        var sett = ctx.Set<T>();
        foreach (var id in enumerable)
        {
            var old = await sett.FindAsync(id.Id);
            if (old is not null)
                sett.Remove(old);
        }

        await ctx.SaveChangesAsync();
    }

    public async Task<T?> GetByIdAsync(Guid dbId, IBaseIdentity id)
    {
        var ctx = myContextRepository.GetContext(dbId);
        if (dbId == Guid.Empty || ctx is null) throw new NullReferenceException($"Db countext '{dbId}' не найден");
        return await ctx.Set<T>().FindAsync(id.Id);
    }

    public async Task<IEnumerable<T>> GetAllAsync(Guid dbId, CancellationToken cancelToken)
    {
        var ctx = myContextRepository.GetContext(dbId);
        if (dbId == Guid.Empty || ctx is null) throw new NullReferenceException($"Db countext '{dbId}' не найден");
        return await ctx.Set<T>().ToListAsync(cancelToken);
    }
}
