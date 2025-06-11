using Common.Helper.Interfaces.Identity;
using Common.Repositories;
using Data.SqlServer.KursSystem.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.SqlServer.KursSystem.Repositories;

public class BaseRepository<T>(KursSystemContext dbContext) : IBaseRepository<T> where T : class
{
    public virtual async Task CreateAsync(T entity)
    {
        await dbContext.Set<T>().AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task CreateManyAsync(IEnumerable<T> entities)
    {
        var enumerable = entities.ToList();
        if (enumerable.Any() != true) return;
        var sett = dbContext.Set<T>();
        foreach (var ent in enumerable.ToList()) sett.Add(ent);
        await dbContext.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(T entity)
    {
        var id = ((IBaseIdentity)entity).Id;
        var old = await dbContext.Set<T>().FindAsync(id);
        if (old is not null)
        {
            dbContext.Set<T>().Remove(old);
            await dbContext.SaveChangesAsync();
        }

        await dbContext.Set<T>().AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }

    public virtual async Task UpdateManyAsync(IEnumerable<T> entities)
    {
        var enumerable = entities.ToList();
        if (enumerable.Any() != true) return;
        var sett = dbContext.Set<T>();
        foreach (var ent in enumerable.ToList()) sett.Update(ent);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(IBaseIdentity id)
    {
        var old = await dbContext.Set<T>().FindAsync(id);
        if (old is not null)
        {
            dbContext.Set<T>().Remove(old);
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task DeleteManyAsync(IEnumerable<IBaseIdentity> ids)
    {
        var enumerable = ids.ToList();
        if (enumerable.Any() != true) return;
        var sett = dbContext.Set<T>();
        foreach (var id in enumerable)
        {
            var old = await sett.FindAsync(id);
            if (old is not null)
                sett.Remove(old);
        }

        await dbContext.SaveChangesAsync();
    }

    public async Task<T?> GetByIdAsync(IBaseIdentity id)
    {
        return await dbContext.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await dbContext.Set<T>().ToListAsync();
    }
}
