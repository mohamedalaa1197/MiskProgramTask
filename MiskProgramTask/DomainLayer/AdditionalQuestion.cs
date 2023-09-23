namespace MiskProgramTask.DomainLayer;

public class AdditionalQuestion
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public List<Question> Questions { get; set; }
}