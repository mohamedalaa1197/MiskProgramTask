namespace MiskProgramTask.ServiceLayer.Application.DTOs;

public class ProfilePayload
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public EducationPayload? Education { get; set; }
    public ExperiencePayload? Experience { get; set; }
    public string? Resume { get; set; }
    public bool ResumeMandatory { get; set; }
    public bool ShowResume { get; set; }
    public List<QuestionPayload>? Questions { get; set; }
}