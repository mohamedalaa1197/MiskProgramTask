namespace MiskProgramTask.ServiceLayer.Application.DTOs;

public class GetApplicationDto
{
    public Guid Id { get; set; }
    public Guid ProgramId { get; set; }
    public string? CoverImageUrl { get; set; }
    public PersonalInformationPayload PersonalInformation { get; set; }
    public ProfilePayload Profile { get; set; }
    public AdditionalQuestionPayload AdditionalQuestion { get; set; }
}