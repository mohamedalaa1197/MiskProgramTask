using MiskProgramTask.Helpers;
using MiskProgramTask.ServiceLayer.Program.DTOs;

namespace MiskProgramTask.ServiceLayer.Program;

public interface IProgramService
{
    Task<BaseResponse<bool>> CreateProgram(ProgramPayload payload);
    Task<BaseResponse<bool>> UpdateProgram(Guid programId, ProgramPayload payload);
    Task<BaseResponse<GetProgramDto?>> GetProgramById(Guid id);
    Task<PaginationOutput<GetAllProgramsDTO?>> GetAllPrograms(BasePage basePage);
}