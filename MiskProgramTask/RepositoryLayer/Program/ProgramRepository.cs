using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using MiskProgramTask.DomainLayer;
using MiskProgramTask.Helpers;
using MiskProgramTask.ServiceLayer.Program.DTOs;

namespace MiskProgramTask.RepositoryLayer;

public class ProgramRepository : IProgramRepository
{
    private readonly ApplicationContext _context;

    public ProgramRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateProgram(DomainLayer.Program program)
    {
        _context.Programs.Add(program);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateProgram(DomainLayer.Program program)
    {
        _context.Programs.Update(program);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<DomainLayer.Program?> GetProgramById(Guid id)
    {
        var entity = await _context.Programs.Include(s => s.Skills).FirstOrDefaultAsync(x => x.Id == id);
        return entity;
    }

    public async Task<(IEnumerable<DomainLayer.Program>, int totalCount)> GetAllPrograms(BasePage basePage)
    {
        var data = _context.Programs.Include(s => s.Skills);
        var totalCount = await data.CountAsync();
        var programs = new List<DomainLayer.Program>();
        if (basePage.pageSize != null && basePage.page != null)
        {
            programs = await data.Skip((basePage.page.Value - 1) * basePage.pageSize.Value)
                .Take(basePage.pageSize.Value)
                .ToListAsync();
        }
        else
        {
            programs = await data.Include(x => x.Skills).ToListAsync();
        }

        return (programs, totalCount);
    }
}