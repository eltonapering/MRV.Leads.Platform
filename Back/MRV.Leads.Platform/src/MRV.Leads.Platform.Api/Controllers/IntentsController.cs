using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MRV.Leads.Platform.Application.CQRS.Commands;
using MRV.Leads.Platform.Application.CQRS.Queries;
using MRV.Leads.Platform.Domain.Entities;
using MRV.Leads.Platform.Domain.Enums;

namespace MRV.Leads.Platform.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class IntentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public IntentsController(IMediator mediator)
    {
        _mediator = mediator;
    }


    /// <summary>
    /// Creates a new intent.
    /// </summary>
    /// <remarks>
    /// Send a command with the details of the new intent to be created.
    /// </remarks>
    /// <param name="command">The command object containing the details for the new intent.</param>
    /// <returns>The created intent object along with the location where it can be accessed.</returns>
    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<Intent>> CreateIntent(CreateIntentCommand command)
    {
        var intent = await _mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { id = intent.Id }, intent);
    }

    /// <summary>
    /// Get Intents by Status.
    /// </summary>
    /// <remarks>
    /// Use 1 for Accepted intents and 2 for Declined intents. 0 é new intent
    /// </remarks>
    /// <param name="status">The status of the intent.</param>
    /// <returns>A list of intents with the specified status.</returns>
    [HttpGet("GetIntentsByStatus/{status}")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Intent>>> GetIntentsByStatus(IntentStatus status)
    {
        var query = new GetIntentByStatusQuery(status);
        var intents = await _mediator.Send(query);
        if (intents == null || !intents.Any()) 
        {
            return Ok(new List<Intent>());
        }

        return Ok(intents);
    }

    /// <summary>
    /// Retrieves a specific intent by its identifier.
    /// </summary>
    /// <remarks>
    /// The intent is searched for by its unique identifier (ID).
    /// </remarks>
    /// <param name="id">The unique identifier of the intent.</param>
    /// <returns>The intent object if found; otherwise, a NotFound result.</returns>
    [HttpGet("{id}")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Intent>> Get(Guid id)
    {
        var query = new GetIntentByIdQuery(id);
        var intent = await _mediator.Send(query);
        if (intent == null)
        {
            return NotFound();
        }

        return Ok(intent);
    }

    /// <summary>
    /// Accepts a specific intent.
    /// </summary>
    /// <remarks>
    /// Marks the intent identified by the ID as accepted.
    /// </remarks>
    /// <param name="id">The unique identifier of the intent to accept.</param>
    /// <returns>An Ok result if the intent was successfully accepted.</returns>
    [HttpPost("{id}/accept")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AcceptIntent(Guid id)
    {
        await _mediator.Send(new AcceptIntentCommand(id));
        return Ok();
    }

    /// <summary>
    /// Declines a specific intent.
    /// </summary>
    /// <remarks>
    /// Marks the intent identified by the ID as declined.
    /// </remarks>
    /// <param name="id">The unique identifier of the intent to decline.</param>
    /// <returns>An Ok result if the intent was successfully declined.</returns>
    [HttpPost("{id}/decline")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeclineIntent(Guid id)
    {
        await _mediator.Send(new DeclineIntentCommand(id));
        return Ok();
    }
}