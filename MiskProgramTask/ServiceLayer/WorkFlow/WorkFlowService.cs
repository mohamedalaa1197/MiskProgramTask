using AutoMapper;
using MiskProgramTask.Helpers;
using MiskProgramTask.RepositoryLayer.WorkFlow;
using MiskProgramTask.ServiceLayer.Program;
using MiskProgramTask.ServiceLayer.WorkFlow.DTOs;

namespace MiskProgramTask.ServiceLayer.WorkFlow;

public class WorkFlowService : IWorkFlowService
{
    private readonly IWorkFlowRepository _workFlowRepository;
    private readonly IMapper _mapper;
    private readonly IProgramService _programService;


    public WorkFlowService(IWorkFlowRepository workFlowRepository, IMapper mapper, IProgramService programService)
    {
        _workFlowRepository = workFlowRepository;
        _mapper = mapper;
        _programService = programService;
    }


    public async Task<BaseResponse<bool>> UpdateWorkFlow(Guid workFlowId, WorkFlowPayload payload)
    {
        try
        {
            var oldEntity = await _workFlowRepository.GetWorkFlowById(workFlowId);
            if (oldEntity is null)
                return new BaseResponse<bool>(false, ResponseCode.Error, "Entity not Found");

            var program = await _programService.GetProgramById(payload.ProgramId);
            if (program.Data is null)
                return new BaseResponse<bool>(false, ResponseCode.Error, "Program not Found");

            var entity = _mapper.Map<DomainLayer.WorkFlow>(payload);
            entity.Id = workFlowId;
            var result = await _workFlowRepository.UpdateWorkFlow(entity);
            return new BaseResponse<bool>(result, ResponseCode.Success, "Update Successfully");
        }
        catch (Exception e)
        {
            return new BaseResponse<bool>(false, ResponseCode.Error, "Something went wrong");
        }
    }

    public async Task<BaseResponse<GetWorkFlowDTO?>> GetWorkFlowById(Guid id)
    {
        try
        {
            var workFlow = await _workFlowRepository.GetWorkFlowById(id);
            if (workFlow is null)
                return new BaseResponse<GetWorkFlowDTO?>(null, ResponseCode.Error, "Entity not Found");

            var result = _mapper.Map<GetWorkFlowDTO>(workFlow);
            return new BaseResponse<GetWorkFlowDTO?>(result, ResponseCode.Success, string.Empty);
        }
        catch (Exception e)
        {
            return new BaseResponse<GetWorkFlowDTO?>(null, ResponseCode.Error, "Something went wrong");
        }
    }
}