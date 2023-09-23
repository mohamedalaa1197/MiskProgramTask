using MiskProgramTask.Helpers;
using MiskProgramTask.ServiceLayer.WorkFlow.DTOs;

namespace MiskProgramTask.ServiceLayer.WorkFlow;

public interface IWorkFlowService
{
    Task<BaseResponse<bool>> UpdateWorkFlow(Guid workFlowId, WorkFlowPayload payload);
    Task<BaseResponse<GetWorkFlowDTO?>> GetWorkFlowById(Guid id);
}