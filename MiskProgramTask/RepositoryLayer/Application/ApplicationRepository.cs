using Microsoft.EntityFrameworkCore;
using MiskProgramTask.DomainLayer;
using MiskProgramTask.Helpers;

namespace MiskProgramTask.RepositoryLayer.Application;

public class ApplicationRepository : IApplicationRepository
{
    private readonly ApplicationContext _context;

    public ApplicationRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateApplication(DomainLayer.Application application)
    {
        _context.Applications.Add(application);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateApplication(DomainLayer.Application application)
    {
        _context.Applications.Update(application);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<DomainLayer.Application?> GetApplicationById(Guid id)
    {
        var entity = await _context.Applications.FirstOrDefaultAsync(x => x.Id == id);
        return entity;
    }

    public async Task<(IEnumerable<DomainLayer.Application>, int totalCount)> GetAllApplications(BasePage basePage)
    {
        var data = _context.Applications.AsQueryable();
        var totalCount = await data.CountAsync();
        var applications = new List<DomainLayer.Application>();
        if (basePage.pageSize != null && basePage.page != null)
        {
            applications = await data.Skip((basePage.page.Value - 1) * basePage.pageSize.Value)
                .Take(basePage.pageSize.Value)
                .ToListAsync();
        }
        else
        {
            applications = await data.ToListAsync();
        }

        return (applications, totalCount);
    }
}