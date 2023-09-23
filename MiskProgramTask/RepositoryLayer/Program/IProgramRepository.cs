using MiskProgramTask.Helpers;
using MiskProgramTask.ServiceLayer.Program.DTOs;

namespace MiskProgramTask.RepositoryLayer;

public interface IProgramRepository
{
    Task<bool> CreateProgram(DomainLayer.Program program);
    Task<bool> UpdateProgram(DomainLayer.Program program);
    Task<DomainLayer.Program?> GetProgramById(Guid id);
    Task<(IEnumerable<DomainLayer.Program>, int totalCount)> GetAllPrograms(BasePage basePage);
}