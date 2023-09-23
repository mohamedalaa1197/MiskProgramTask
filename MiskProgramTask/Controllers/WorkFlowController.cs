using Microsoft.AspNetCore.Mvc;
using MiskProgramTask.Helpers;
using MiskProgramTask.ServiceLayer.Application;
using MiskProgramTask.ServiceLayer.Application.DTOs;
using MiskProgramTask.ServiceLayer.Program;
using MiskProgramTask.ServiceLayer.Program.DTOs;
using MiskProgramTask.ServiceLayer.WorkFlow;
using MiskProgramTask.ServiceLayer.WorkFlow.DTOs;

namespace MiskProgramTask.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkFlowController : ControllerBase
{
    private readonly IWorkFlowService _workFlowService;

    public WorkFlowController(IWorkFlowService workFlowService)
    {
        _workFlowService = workFlowService;
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateApplication(Guid programId, [FromBody] WorkFlowPayload payload)
    {
        var result = await _workFlowService.UpdateWorkFlow(programId, payload);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetApplicationById(Guid id)
    {
        var result = await _workFlowService.GetWorkFlowById(id);
        return Ok(result);
    }
}