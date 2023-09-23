using Microsoft.EntityFrameworkCore;
using MiskProgramTask.DomainLayer;

namespace MiskProgramTask.RepositoryLayer.WorkFlow;

public class WorkFlowRepository : IWorkFlowRepository
{
    private readonly ApplicationContext _context;

    public WorkFlowRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<bool> UpdateWorkFlow(DomainLayer.WorkFlow workFlow)
    {
        _context.WorkFlows.Update(workFlow);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<DomainLayer.WorkFlow?> GetWorkFlowById(Guid id)
    {
        var entity = await _context.WorkFlows.FirstOrDefaultAsync(x => x.Id == id);
        return entity;
    }
}