using Common.Helper.Interfaces.Identity;
using Common.Repositories;
using Data.SqlServer.KursSystem.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.SqlServer.Base;

public class BaseRepository<T>(KursSystemContext dbContext) : IBaseRepository<T> where T : class, IBaseIdentity
{
    public virtual async Task CreateAsync(T entity)
    {
        var id = entity.Id;
        if (id is int i && i == 0)
        {
            i = (int)await dbContext.Set<T>().MaxAsync(_ => _.Id) + 1;
            entity.Id = i;
        } 
        if (id is decimal d && d == 0)
        {
            d = (decimal)await dbContext.Set<T>().MaxAsync(_ => _.Id) + 1;
            entity.Id = d;
        } 
        if (id is Guid g && g == Guid.Empty)
        {
            entity.Id = Guid.NewGuid();
        }
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
        //var id = ((IBaseIdentity)entity).Id;
        //var old = await dbContext.Set<T>().FindAsync(id);
        //if (old is not null)
        //{
            dbContext.Set<T>().Update(entity);
            await dbContext.SaveChangesAsync();
        //}
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
        var old = await dbContext.Set<T>().FindAsync(id.Id);
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
            var old = await sett.FindAsync(id.Id);
            if (old is not null)
                sett.Remove(old);
        }

        await dbContext.SaveChangesAsync();
    }

    public async Task<T?> GetByIdAsync(IBaseIdentity id)
    {
        return await dbContext.Set<T>().FindAsync(id.Id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await dbContext.Set<T>().ToListAsync();
    }
}


