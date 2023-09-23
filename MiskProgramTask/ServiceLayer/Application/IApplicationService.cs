using MiskProgramTask.Helpers;
using MiskProgramTask.ServiceLayer.Application.DTOs;
using MiskProgramTask.ServiceLayer.Program.DTOs;

namespace MiskProgramTask.ServiceLayer.Application;

public interface IApplicationService
{
    Task<BaseResponse<bool>> CreateApplication(AddApplicationPayload payload);
    Task<BaseResponse<bool>> UpdateApplication(Guid applicationId, AddApplicationPayload payload);
    Task<BaseResponse<GetApplicationDto?>> GetApplicationById(Guid id);
    Task<PaginationOutput<GetApplicationDto?>> GetAllApplications(BasePage basePage, Guid programId);
}