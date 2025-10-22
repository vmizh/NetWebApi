using Data.SqlServer.KursReferences.Context;
using Data.SqlServer.KursReferences.Entities;
using Data.SqlServer.KursReferences.Repositories.Base;

namespace Data.SqlServer.KursReferences.Repositories.ProjectRepository;

public class ProjectRepository(IKursReferenceContextRepository repository)
    : KursReferencesBaseRepository<Project>(repository), IProjectRepository
{
}
