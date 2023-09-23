namespace MiskProgramTask.DomainLayer;

public class Profile
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Education? Education { get; set; }
    public Experience? Experience { get; set; }
    public bool ExperienceMandatory { get; set; }
    public bool ShowExperience { get; set; }
    public string? Resume { get; set; }
    public bool ResumeMandatory { get; set; }
    public bool ShowResume { get; set; }
    public List<Question>? Questions { get; set; }
}

public class Education
{
    public bool EducationMandatory { get; set; }
    public bool ShowEducation { get; set; }
    public List<Question>? Questions { get; set; }
}

public class Experience
{
    public bool ExperienceMandatory { get; set; }
    public bool ShowExperience { get; set; }
    public List<Question>? Questions { get; set; }
}