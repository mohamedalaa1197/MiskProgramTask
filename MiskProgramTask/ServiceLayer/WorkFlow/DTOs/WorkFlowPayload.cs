using MiskProgramTask.DomainLayer;

namespace MiskProgramTask.ServiceLayer.WorkFlow.DTOs;

public class WorkFlowPayload
{
    public Guid ProgramId { get; set; }
    public List<string> Stages { get; set; }
    public string? StageName { get; set; }
    public StageType Type { get; set; }
    public VideoStagePayload? VideoStage { get; set; }
}

public class VideoStagePayload
{
    public string? VideoQuestion { get; set; }
    public string? Description { get; set; }
    public int MaxDuration { get; set; }
    public DurationType DurationType { get; set; }
    public int DeadLineInDays { get; set; }
}