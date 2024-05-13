using Microsoft.AspNetCore.Mvc;

namespace zadanie4.zadanie4;

[Route("api/stored/warehouse")]
[ApiController]
public class WarehouseController2 : ControllerBase
{
    private readonly IAssignmentService _assignmentService;

    public WarehouseController2(IAssignmentService assignmentService)
    {
        _assignmentService = assignmentService;
    }

    [HttpPost]
    public async Task<IActionResult> FulfillAssignment(Assignment dto)
    {
        var success = await _assignmentService.AddAssignmentProcedure(dto);
        return success != null ? StatusCode(StatusCodes.Status201Created) : Conflict();
    }
}