using Microsoft.AspNetCore.Mvc;
using MiskProgramTask.Helpers;
using MiskProgramTask.ServiceLayer.Application;
using MiskProgramTask.ServiceLayer.Application.DTOs;
using MiskProgramTask.ServiceLayer.Program;
using MiskProgramTask.ServiceLayer.Program.DTOs;

namespace MiskProgramTask.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationController : ControllerBase
{
    private readonly IApplicationService _applicationService;

    public ApplicationController(IApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateApplication([FromBody] AddApplicationPayload payload)
    {
        var result = await _applicationService.CreateApplication(payload);
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateApplication(Guid programId, [FromBody] AddApplicationPayload programPayload)
    {
        var result = await _applicationService.UpdateApplication(programId, programPayload);
        return Ok(result);
    }

    [HttpGet("{programId}")]
    public async Task<IActionResult> GetAllApplications(Guid programId, [FromQuery] BasePage basePage)
    {
        var result = await _applicationService.GetAllApplications(basePage, programId);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetApplicationById(Guid id)
    {
        var result = await _applicationService.GetApplicationById(id);
        return Ok(result);
    }
}