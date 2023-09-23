namespace MiskProgramTask.RepositoryLayer.WorkFlow;

public interface IWorkFlowRepository
{
    Task<bool> UpdateWorkFlow(DomainLayer.WorkFlow workFlow);
    Task<DomainLayer.WorkFlow?> GetWorkFlowById(Guid id);
}