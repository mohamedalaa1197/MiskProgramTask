using AutoMapper;
using MiskProgramTask.DomainLayer;
using MiskProgramTask.Helpers;
using MiskProgramTask.RepositoryLayer;
using MiskProgramTask.ServiceLayer.Program.DTOs;

namespace MiskProgramTask.ServiceLayer.Program;

public class ProgramService : IProgramService
{
    private readonly IProgramRepository _programRepository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly IHostEnvironment _environment;

    public ProgramService(IProgramRepository programRepository, IMapper mapper, IConfiguration configuration,
        IHostEnvironment environment)
    {
        _programRepository = programRepository;
        _mapper = mapper;
        _configuration = configuration;
        _environment = environment;
    }

    public async Task<BaseResponse<bool>> CreateProgram(ProgramPayload payload)
    {
        try
        {
            var (descriptionUrl, benefitsUrl, criteriaUrl) = await UploadProgramFile(payload.DescriptionImageUrl,
                payload.BenefitsImageUrl,
                payload.CriteriaUrl);

            var entity = _mapper.Map<DomainLayer.Program>(payload);
            entity.Skills = _mapper.Map<ICollection<Skill>?>(payload.Skills);
            entity.DescriptionImageUrl = descriptionUrl;
            entity.CriteriaUrl = criteriaUrl;
            entity.BenefitsImageUrl = benefitsUrl;
            var result = await _programRepository.CreateProgram(entity);
            return new BaseResponse<bool>(true, ResponseCode.Success, "Added Successfully");
        }
        catch (Exception e)
        {
            return new BaseResponse<bool>(false, ResponseCode.Error, "Something went wrong");
        }
    }

    public async Task<BaseResponse<bool>> UpdateProgram(Guid programId, ProgramPayload payload)
    {
        try
        {
            var oldEntity = await _programRepository.GetProgramById(programId);
            if (oldEntity is null)
                return new BaseResponse<bool>(false, ResponseCode.Error, "Entity not Found");

            var (descriptionUrl, benefitsUrl, criteriaUrl) = await UploadProgramFile(payload.DescriptionImageUrl,
                payload.BenefitsImageUrl,
                payload.CriteriaUrl);

            var entity = _mapper.Map<DomainLayer.Program>(payload);
            entity.Skills = _mapper.Map<ICollection<Skill>?>(payload.Skills);
            entity.Id = programId;
            entity.DescriptionImageUrl = descriptionUrl;
            entity.CriteriaUrl = criteriaUrl;
            entity.BenefitsImageUrl = benefitsUrl;
            var result = await _programRepository.UpdateProgram(entity);
            return new BaseResponse<bool>(true, ResponseCode.Success, "Update Successfully");
        }
        catch (Exception e)
        {
            return new BaseResponse<bool>(false, ResponseCode.Error, "Something went wrong");
        }
    }

    public async Task<BaseResponse<GetProgramDto?>> GetProgramById(Guid programId)
    {
        try
        {
            var entity = await _programRepository.GetProgramById(programId);
            if (entity is null)
                return new BaseResponse<GetProgramDto?>(null, ResponseCode.Error, "Entity Not Found");

            var result = _mapper.Map<GetProgramDto>(entity);
            result.Skills = _mapper.Map<ICollection<string>>(entity.Skills);
            return new BaseResponse<GetProgramDto?>(result, ResponseCode.Success, string.Empty);
        }
        catch (Exception e)
        {
            return new BaseResponse<GetProgramDto?>(null, ResponseCode.Error, "Something went wrong");
        }
    }

    public async Task<PaginationOutput<GetAllProgramsDTO?>> GetAllPrograms(BasePage basePage)
    {
        try
        {
            var entities = await _programRepository.GetAllPrograms(basePage);
            var result = _mapper.Map<List<GetAllProgramsDTO>>(entities.Item1);

            return new PaginationOutput<GetAllProgramsDTO?>(result, entities.totalCount, ResponseCode.Success,
                string.Empty);
        }
        catch (Exception e)
        {
            return new PaginationOutput<GetAllProgramsDTO?>(null, 0, ResponseCode.Error, "Something went wrong");
        }
    }

    private async Task<(string descriptionUrl, string benefitsUrl, string criteriaUrl)> UploadProgramFile(
        IFormFile? description,
        IFormFile? benefits, IFormFile? criteria)
    {
        var descriptionUrl = "";
        var benefitsUrl = "";
        var criteriaUrl = "";

        // upload to external Storage service
        if (description != null)
        {
            descriptionUrl = await ExtensionMethods.UploadFiles(
                description, _configuration,
                _environment);
        }

        if (criteria != null)
        {
            criteriaUrl = await ExtensionMethods.UploadFiles(
                criteria, _configuration,
                _environment);
        }

        if (benefits != null)
        {
            benefitsUrl = await ExtensionMethods.UploadFiles(
                benefits, _configuration,
                _environment);
        }

        return (descriptionUrl, benefitsUrl, criteriaUrl);
    }
}