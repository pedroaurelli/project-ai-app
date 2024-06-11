using Microsoft.AspNetCore.Mvc;
using Services.ActionValues;
using Services.ActionValues.CreateActionValue;

namespace project_ai.Controllers;

[Route("action-values")]
public class ActionValuesController : Controller
{
    [HttpPost]
    public async Task<ActionResult<ActionValueResult>> CreateActionValue(
        [FromBody] CreateActionValueCommand command,
        [FromServices] CreateActionValueService createActionValueService)
    {
        var result = await createActionValueService.CreateActionValueAsync(command);

        return Ok(result);
    }
}
