using System.ComponentModel.DataAnnotations;
using MiskProgramTask.DomainLayer;

namespace MiskProgramTask.ServiceLayer.Program.DTOs;

public class GetProgramDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Summary { get; set; }
    public string Description { get; set; }
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
    public string Location { get; set; }
    public bool FullyRemote { get; set; }
    public Qualifications? MinQualifications { get; set; }
    public long MaxNumberOfApplications { get; set; }
    public ICollection<string>? Skills { get; set; }
}