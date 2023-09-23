namespace MiskProgramTask.DomainLayer;

public class Application
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ProgramId { get; set; }
    public string? CoverImageUrl { get; set; }
    public PersonalInformation PersonalInformation { get; set; }
    public Profile Profile { get; set; }
    public AdditionalQuestion AdditionalQuestion { get; set; }
}