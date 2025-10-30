using Data.SqlServer.KursReferences.Context;
using Microsoft.EntityFrameworkCore;
using Common.Repositories.Specification;

namespace Data.SqlServer.Extensions;

public static class SpecificationExtensions
{
    public static IQueryable<TEntity> ApplySpecification<TEntity>(
        this KursReferenceContext dbContext,
        ISpecification<TEntity> specification) where TEntity : class
    {
        var efCoreSpecification = new EfCoreSpecification<TEntity>(specification);

        var query = dbContext.Set<TEntity>().AsNoTracking();
        query = efCoreSpecification.Apply(query);

        return query;
    }
}
