using AutoMapper;
using MiskProgramTask.Helpers;
using MiskProgramTask.RepositoryLayer.Application;
using MiskProgramTask.ServiceLayer.Application.DTOs;

namespace MiskProgramTask.ServiceLayer.Application;

public class ApplicationService : IApplicationService
{
    private readonly IMapper _mapper;
    public IApplicationRepository _applicationRepository { get; set; }

    public ApplicationService(IApplicationRepository applicationRepository, IMapper mapper)
    {
        _mapper = mapper;
        _applicationRepository = applicationRepository;
    }

    public async Task<BaseResponse<bool>> CreateApplication(AddApplicationPayload payload)
    {
        try
        {
            var entity = _mapper.Map<DomainLayer.Application>(payload);
            var result = await _applicationRepository.CreateApplication(entity);
            return new BaseResponse<bool>(result, ResponseCode.Success, "Created Successfully");
        }
        catch (Exception e)
        {
            return new BaseResponse<bool>(false, ResponseCode.Error, "Something went wrong");
        }
    }

    public async Task<BaseResponse<bool>> UpdateApplication(Guid applicationId, AddApplicationPayload payload)
    {
        try
        {
            var application = await _applicationRepository.GetApplicationById(applicationId);
            if (application is null)
                return new BaseResponse<bool>(false, ResponseCode.Error, "Application Not Found");

            var entity = _mapper.Map<DomainLayer.Application>(payload);
            entity.Id = applicationId;
            var result = await _applicationRepository.UpdateApplication(entity);
            return new BaseResponse<bool>(result, ResponseCode.Success, "Created Successfully");
        }
        catch (Exception e)
        {
            return new BaseResponse<bool>(false, ResponseCode.Error, "Something went wrong");
        }
    }

    public async Task<BaseResponse<GetApplicationDto?>> GetApplicationById(Guid id)
    {
        try
        {
            var application = await _applicationRepository.GetApplicationById(id);
            if (application is null)
                return new BaseResponse<GetApplicationDto?>(null, ResponseCode.Error, "Application Not Found");

            var entity = _mapper.Map<GetApplicationDto>(application);
            return new BaseResponse<GetApplicationDto?>(entity, ResponseCode.Success, string.Empty);
        }
        catch (Exception e)
        {
            return new BaseResponse<GetApplicationDto?>(null, ResponseCode.Error, "Something went wrong");
        }
    }

    public async Task<PaginationOutput<GetApplicationDto?>> GetAllApplications(BasePage basePage, Guid programId)
    {
        try
        {
            var applications = await _applicationRepository.GetAllApplications(basePage);
            var entity = _mapper.Map<List<GetApplicationDto>>(applications);
            return new PaginationOutput<GetApplicationDto?>(entity, applications.totalCount, ResponseCode.Success,
                string.Empty);
        }
        catch (Exception e)
        {
            return new PaginationOutput<GetApplicationDto?>(null, 0, ResponseCode.Error, "Something went wrong");
        }
    }
    
    
}