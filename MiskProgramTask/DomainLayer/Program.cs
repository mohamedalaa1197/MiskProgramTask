using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MiskProgramTask.DomainLayer;

public class Program
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required] public string Title { get; set; }
    public string? Summary { get; set; }
    [Required] public string Description { get; set; }
    public string? DescriptionImageUrl { get; set; }
    public string? Benefits { get; set; }
    public string? BenefitsImageUrl { get; set; }
    public string? Criteria { get; set; }
    public string? CriteriaUrl { get; set; }
    public ProgramType? Type { get; set; }
    public DateTime? StartAt { get; set; }
    public DateTime? OpenAt { get; set; }
    public DateTime? ClosedAt { get; set; }
    public string? Duration { get; set; }
    [Required] public string Location { get; set; }
    public bool FullyRemote { get; set; }
    public Qualifications? MinQualifications { get; set; }

    public long MaxNumberOfApplications { get; set; }
    public ICollection<Skill>? Skills { get; set; }
}

public enum ProgramType
{
    FullTime = 0,
    PartTime = 1,
    Internship = 2
}

public enum Qualifications
{
    HighSchool,
    Bachelor,
    Master
}