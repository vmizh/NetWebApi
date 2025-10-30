using Common.Helper.Interfaces.Identity;
using Data.SqlServer.KursReferences.Context;
using Data.SqlServer.KursSystem.Context;
using Microsoft.EntityFrameworkCore;
using Common.Repositories;
using Common.Repositories.Specification;

namespace Data.SqlServer.Base;

public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseIdentity
{
    protected readonly DbContext myDbContext;

    public BaseRepository(KursSystemContext myDbContext)
    {
        this.myDbContext = myDbContext;
    }

    public BaseRepository(KursReferenceContext myDbContext)
    {
        this.myDbContext = myDbContext;
    }

    public virtual async Task CreateAsync(T entity)
    {
        var id = entity.Id;
        switch (id)
        {
            case int i when i == 0:
                i = (int)await myDbContext.Set<T>().MaxAsync(_ => _.Id) + 1;
                entity.Id = i;
                break;
            case decimal d when d == 0:
                d = (decimal)await myDbContext.Set<T>().MaxAsync(_ => _.Id) + 1;
                entity.Id = d;
                break;
            case Guid g when g == Guid.Empty:
                entity.Id = Guid.NewGuid();
                break;
        }

        await myDbContext.Set<T>().AddAsync(entity);
        await myDbContext.SaveChangesAsync();
    }

    public async Task CreateManyAsync(IEnumerable<T> entities)
    {

        var enumerable = entities.ToList();
        if (enumerable.Any() != true) return;
        var sett = myDbContext.Set<T>();
        foreach (var ent in enumerable.ToList())
        {
            var id = ent.Id;
            switch (id)
            {
                case int i when i == 0:
                    i = (int)await myDbContext.Set<T>().MaxAsync(_ => _.Id) + 1;
                    ent.Id = i;
                    break;
                case decimal d when d == 0:
                    d = (decimal)await myDbContext.Set<T>().MaxAsync(_ => _.Id) + 1;
                    ent.Id = d;
                    break;
                case Guid g when g == Guid.Empty:
                    ent.Id = Guid.NewGuid();
                    break;
            }

            sett.Add(ent);
        }
        await myDbContext.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(T entity)
    {
            myDbContext.Set<T>().Update(entity);
            await myDbContext.SaveChangesAsync();
    }

    public virtual async Task UpdateManyAsync(IEnumerable<T> entities)
    {
        var enumerable = entities.ToList();
        if (enumerable.Any() != true) return;
        var sett = myDbContext.Set<T>();
        foreach (var ent in enumerable.ToList()) sett.Update(ent);
        await myDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(IBaseIdentity id)
    {
        var old = await myDbContext.Set<T>().FindAsync(id.Id);
        if (old is not null)
        {
            myDbContext.Set<T>().Remove(old);
            await myDbContext.SaveChangesAsync();
        }
    }

    public async Task DeleteManyAsync(IEnumerable<IBaseIdentity> ids)
    {
        var enumerable = ids.ToList();
        if (enumerable.Any() != true) return;
        var sett = myDbContext.Set<T>();
        foreach (var id in enumerable)
        {
            var old = await sett.FindAsync(id.Id);
            if (old is not null)
                sett.Remove(old);
        }

        await myDbContext.SaveChangesAsync();
    }

    public async Task<T?> GetByIdAsync(IBaseIdentity id)
    {
        return await myDbContext.Set<T>().FindAsync(id.Id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await myDbContext.Set<T>().ToListAsync();
    }

    public async Task<IEnumerable<T>> WhereAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
    {
        var efCoreSpecification = new EfCoreSpecification<T>(specification);

        var query = myDbContext.Set<T>().AsNoTracking();
        query = efCoreSpecification.Apply(query);

        return await query.ToListAsync(cancellationToken).ConfigureAwait(false);
    }
}


public class BaseDbRepository<T>(KursReferenceContextRepository contextReppository) : IBaseDbRepository<T>
    where T : class, IBaseIdentity
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    protected KursReferenceContext myDbContext;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    protected readonly KursReferenceContextRepository myContextRepository = contextReppository;


    public virtual async Task CreateAsync(T entity)
    {
        var id = entity.Id;
        switch (id)
        {
            case int i when i == 0:
                i = (int)await myDbContext.Set<T>().MaxAsync(_ => _.Id) + 1;
                entity.Id = i;
                break;
            case decimal d when d == 0:
                d = (decimal)await myDbContext.Set<T>().MaxAsync(_ => _.Id) + 1;
                entity.Id = d;
                break;
            case Guid g when g == Guid.Empty:
                entity.Id = Guid.NewGuid();
                break;
        }

        await myDbContext.Set<T>().AddAsync(entity);
        await myDbContext.SaveChangesAsync();
    }

    public async Task CreateManyAsync(IEnumerable<T> entities)
    {

        var enumerable = entities.ToList();
        if (enumerable.Any() != true) return;
        var sett = myDbContext.Set<T>();
        foreach (var ent in enumerable.ToList())
        {
            var id = ent.Id;
            switch (id)
            {
                case int i when i == 0:
                    i = (int)await myDbContext.Set<T>().MaxAsync(_ => _.Id) + 1;
                    ent.Id = i;
                    break;
                case decimal d when d == 0:
                    d = (decimal)await myDbContext.Set<T>().MaxAsync(_ => _.Id) + 1;
                    ent.Id = d;
                    break;
                case Guid g when g == Guid.Empty:
                    ent.Id = Guid.NewGuid();
                    break;
            }

            sett.Add(ent);
        }
        await myDbContext.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(T entity)
    {
            myDbContext.Set<T>().Update(entity);
            await myDbContext.SaveChangesAsync();
    }

    public virtual async Task UpdateManyAsync(IEnumerable<T> entities)
    {
        var enumerable = entities.ToList();
        if (enumerable.Any() != true) return;
        var sett = myDbContext.Set<T>();
        foreach (var ent in enumerable.ToList()) sett.Update(ent);
        await myDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(IBaseIdentity id)
    {
        var old = await myDbContext.Set<T>().FindAsync(id.Id);
        if (old is not null)
        {
            myDbContext.Set<T>().Remove(old);
            await myDbContext.SaveChangesAsync();
        }
    }

    public async Task DeleteManyAsync(IEnumerable<IBaseIdentity> ids)
    {
        var enumerable = ids.ToList();
        if (enumerable.Any() != true) return;
        var sett = myDbContext.Set<T>();
        foreach (var id in enumerable)
        {
            var old = await sett.FindAsync(id.Id);
            if (old is not null)
                sett.Remove(old);
        }

        await myDbContext.SaveChangesAsync();
    }

    public async Task<T?> GetByIdAsync(IBaseIdentity id)
    {
        return await myDbContext.Set<T>().FindAsync(id.Id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await myDbContext.Set<T>().ToListAsync();
    }

    public async Task<IEnumerable<T>> WhereAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
    {
        var efCoreSpecification = new EfCoreSpecification<T>(specification);

        var query = myDbContext.Set<T>().AsNoTracking();
        query = efCoreSpecification.Apply(query);

        return await query.ToListAsync(cancellationToken).ConfigureAwait(false);
    }

    public void SetDbContext(string name)
    {
#pragma warning disable CS8601 // Possible null reference assignment.
        myDbContext = myContextRepository.GetContext(name);
#pragma warning restore CS8601 // Possible null reference assignment.
        if(myDbContext is null)
        {
            throw new NullReferenceException("DbContext is null");
        }
    }

    public void SetDbContext(Guid id)
    {
#pragma warning disable CS8601 // Possible null reference assignment.
        myDbContext = myContextRepository.GetContext(id);
#pragma warning restore CS8601 // Possible null reference assignment.
        if(myDbContext is null)
        {
            throw new NullReferenceException("DbContext is null");
        }
    }

    public string GetDbName(Guid id)
    {
        return myContextRepository.GetContextName(id);
    }
}

