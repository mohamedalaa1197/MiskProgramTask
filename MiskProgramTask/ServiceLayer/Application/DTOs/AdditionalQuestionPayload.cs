namespace MiskProgramTask.ServiceLayer.Application.DTOs;

public class AdditionalQuestionPayload
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public List<QuestionPayload> Questions { get; set; }
}