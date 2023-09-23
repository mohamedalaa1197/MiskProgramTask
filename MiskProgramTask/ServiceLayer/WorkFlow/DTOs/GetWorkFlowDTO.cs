using MiskProgramTask.DomainLayer;

namespace MiskProgramTask.ServiceLayer.WorkFlow.DTOs;

public class GetWorkFlowDTO
{
    public Guid ProgramId { get; set; }
    public List<string> Stages { get; set; }
    public string? StageName { get; set; }
    public StageType Type { get; set; }
    public VideoStagePayload? VideoStage { get; set; }
}