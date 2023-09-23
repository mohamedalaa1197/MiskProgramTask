namespace MiskProgramTask.DomainLayer;

public class PersonalInformation
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public bool InternalPhone { get; set; }
    public bool ShowPhone { get; set; }
    public string? Nationality { get; set; }
    public string? InternalNationality { get; set; }
    public string? ShowNationality { get; set; }
    public string? CurrentResidence { get; set; }
    public string? InternalCurrentResidence { get; set; }
    public string? ShowCurrentResidence { get; set; }
    public string? IdNumber { get; set; }
    public string? InternalIdNumber { get; set; }
    public string? ShowIdNumber { get; set; }
    public string? DateOfBirth { get; set; }
    public string? InternalDateOfBirth { get; set; }
    public string? ShowDateOfBirth { get; set; }
    public string? Gender { get; set; }
    public string? InternalGender { get; set; }
    public string? ShowGender { get; set; }
    public List<Question>? Questions { get; set; }
}