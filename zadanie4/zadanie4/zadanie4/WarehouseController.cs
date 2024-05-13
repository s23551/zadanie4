using Microsoft.AspNetCore.Mvc;
using zadanie4.Model;

namespace zadanie4.zadanie4;

[Route("api/assignment")]
[ApiController]
public class WarehouseController : ControllerBase
{
    private readonly IAssignmentService _assignmentService;

    public WarehouseController(IAssignmentService assignmentService)
    {
        _assignmentService = assignmentService;
    }

    [HttpPost]
    public async Task<IActionResult> AddOrder([FromBody] Assignment dto)
    {
        var success = await _assignmentService.AddAssignment(dto);
        return success != null ? StatusCode(StatusCodes.Status201Created) : Conflict();
    }
}