namespace MiskProgramTask.DomainLayer;

public class WorkFlow
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ProgramId { get; set; }
    public List<string> Stages { get; set; }
    public string? StageName { get; set; }
    public StageType Type { get; set; }
    public VideoStage? VideoStage { get; set; }
}

public enum StageType
{
    Shortlisting,
    VideoInterview,
    Placement
}

public class VideoStage
{
    public string? VideoQuestion { get; set; }
    public string? Description { get; set; }
    public int MaxDuration { get; set; }
    public DurationType DurationType { get; set; }
    public int DeadLineInDays { get; set; }
}

public enum DurationType
{
    SecOrMin,
    Hours
}