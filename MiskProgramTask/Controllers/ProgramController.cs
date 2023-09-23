using Microsoft.AspNetCore.Mvc;
using MiskProgramTask.Helpers;
using MiskProgramTask.ServiceLayer.Program;
using MiskProgramTask.ServiceLayer.Program.DTOs;

namespace MiskProgramTask.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProgramController : ControllerBase
{
    private readonly IProgramService _programService;

    public ProgramController(IProgramService programService)
    {
        _programService = programService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateProgram([FromForm] ProgramPayload programPayload)
    {
        var result = await _programService.CreateProgram(programPayload);
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateProgram(Guid programId, [FromForm] ProgramPayload programPayload)
    {
        var result = await _programService.UpdateProgram(programId, programPayload);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProgramById(Guid id)
    {
        var result = await _programService.GetProgramById(id);
        return Ok(result);
    }
    [HttpGet]
    public async Task<IActionResult> GetAllPrograms([FromQuery] BasePage basePage)
    {
        var result = await _programService.GetAllPrograms(basePage);
        return Ok(result);
    }

}