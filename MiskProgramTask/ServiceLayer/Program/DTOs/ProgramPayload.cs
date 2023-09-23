using System.ComponentModel.DataAnnotations;
using MiskProgramTask.DomainLayer;

namespace MiskProgramTask.ServiceLayer.Program.DTOs;

public class ProgramPayload
{
    public Guid Title { get; set; } = Guid.NewGuid();
    public string? Summary { get; set; }
    public string? Description { get; set; }
    public IFormFile? DescriptionImageUrl { get; set; }
    public string? Benefits { get; set; }
    public IFormFile? BenefitsImageUrl { get; set; }
    public string? Criteria { get; set; }
    public IFormFile? CriteriaUrl { get; set; }
    public ProgramType? Type { get; set; }
    public DateTime? StartAt { get; set; }
    public DateTime? OpenAt { get; set; }
    public DateTime? ClosedAt { get; set; }
    public string? Duration { get; set; }
    public string? Location { get; set; }
    public bool FullyRemote { get; set; }
    public Qualifications? MinQualifications { get; set; }
    public long MaxNumberOfApplications { get; set; }
    public ICollection<string>? Skills { get; set; }
}