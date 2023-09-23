using MiskProgramTask.Helpers;

namespace MiskProgramTask.RepositoryLayer.Application;

public interface IApplicationRepository
{
    Task<bool> CreateApplication(DomainLayer.Application application);
    Task<bool> UpdateApplication(DomainLayer.Application application);
    Task<DomainLayer.Application?> GetApplicationById(Guid id);
    Task<(IEnumerable<DomainLayer.Application>, int totalCount)> GetAllApplications(BasePage basePage);
}