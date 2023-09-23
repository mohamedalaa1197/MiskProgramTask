namespace MiskProgramTask.ServiceLayer.Application.DTOs;

public class EducationPayload
{
    public bool EducationMandatory { get; set; }
    public bool ShowEducation { get; set; }
    public List<QuestionPayload>? Questions { get; set; }
}

public class ExperiencePayload
{
    public bool ExperienceMandatory { get; set; }
    public bool ShowExperience { get; set; }
    public List<QuestionPayload>? Questions { get; set; }
}