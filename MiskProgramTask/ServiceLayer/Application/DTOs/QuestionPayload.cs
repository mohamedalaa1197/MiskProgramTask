using MiskProgramTask.DomainLayer;

namespace MiskProgramTask.ServiceLayer.Application.DTOs;

public class QuestionPayload
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public QuestionType Type { get; set; }
    public string? QuestionValue { get; set; }
    public string Title { get; set; }
    public List<string>? Choices { get; set; }
    public int? MaxChoiceAllowed { get; set; }
    public bool? EnableOtherOption { get; set; }
    public bool? DisQualifyIfAnswerNo { get; set; }
    public DateTime? DateValue { get; set; }
    public int? NumberValue { get; set; }
    public bool Mandatory { get; set; }
    public bool Hide { get; set; }
}