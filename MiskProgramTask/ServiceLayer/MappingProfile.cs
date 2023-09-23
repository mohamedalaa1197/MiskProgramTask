using MiskProgramTask.DomainLayer;
using MiskProgramTask.ServiceLayer.Application.DTOs;
using MiskProgramTask.ServiceLayer.Program.DTOs;
using MiskProgramTask.ServiceLayer.WorkFlow.DTOs;
using Profile = AutoMapper.Profile;

namespace MiskProgramTask.ServiceLayer;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DomainLayer.Program, ProgramPayload>()
            .ReverseMap()
            .ForMember(x => x.Skills, o => o.Ignore());

        CreateMap<string, Skill>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src))
            .ReverseMap();

        CreateMap<GetProgramDto, DomainLayer.Program>()
            .ReverseMap();

        CreateMap<GetAllProgramsDTO, DomainLayer.Program>()
            .ReverseMap();

        CreateMap<AddApplicationPayload, DomainLayer.Application>()
            .ForMember(x => x.Profile, o => o.MapFrom(q => q.Profile))
            .ForMember(x => x.AdditionalQuestion, o => o.MapFrom(q => q.AdditionalQuestion))
            .ForMember(x => x.PersonalInformation, o => o.MapFrom(q => q.PersonalInformation))
            .ReverseMap();

        CreateMap<ProfilePayload, DomainLayer.Profile>()
            .ForMember(x => x.Education, o => o.MapFrom(q => q.Education))
            .ForMember(x => x.Experience, o => o.MapFrom(q => q.Experience))
            .ForMember(x => x.Questions, o => o.MapFrom(q => q.Questions))
            .ReverseMap();

        CreateMap<QuestionPayload, Question>().ReverseMap();

        CreateMap<GetApplicationDto, DomainLayer.Application>().ReverseMap()
            .ForMember(x => x.Profile, o => o.MapFrom(q => q.Profile))
            .ForMember(x => x.AdditionalQuestion, o => o.MapFrom(q => q.AdditionalQuestion))
            .ForMember(x => x.PersonalInformation, o => o.MapFrom(q => q.PersonalInformation));


        CreateMap<WorkFlowPayload, DomainLayer.WorkFlow>()
            .ReverseMap();

        CreateMap<GetWorkFlowDTO, DomainLayer.WorkFlow>()
            .ReverseMap();
    }
}