using EmployeeManagement.Utility.Responses;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Utility.Utility;

[ApiController]
public class BaseApiController : ControllerBase
{
    protected IActionResult SuccessResponse<T>(T data, string message = "Request successful.")
    {
        return Ok(new Envelope<T>
        {
            Success = true,
            Message = message,
            Data = data
        });
    }

    protected IActionResult CreatedResponse<T>(string actionName, object routeValues, T data, string message = "Resource created successfully.")
    {
        return CreatedAtAction(actionName, routeValues, new Envelope<T>
        {
            Success = true,
            Message = message,
            Data = data
        });
    }

    protected IActionResult ErrorResponse(string message)
    {
        return BadRequest(new BaseResponse
        {
            Success = false,
            Message = message
        });
    }
}