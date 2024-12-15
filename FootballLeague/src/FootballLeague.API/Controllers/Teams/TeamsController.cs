using FootballLeague.API.Controllers.Teams.Requests;
using FootballLeague.Application.Teams.AddTeam;
using FootballLeague.Application.Teams.DeleteTeam;
using FootballLeague.Application.Teams.GetAllTeams;
using FootballLeague.Application.Teams.GetTeamById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FootballLeague.API.Controllers.Teams;

[ApiController]
[Route("api/teams")]
public class TeamsController : ControllerBase
{
    private readonly ISender _sender;

    public TeamsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllTeamsQuery();

        var result = await _sender.Send(query);

        return Ok(result);
    }

    [HttpGet("getById/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetTeamByIdQuery(id);

        var result = await _sender.Send(query);

        return Ok(result);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CreateTeamRequest request)
    {
        var command = new AddTeamCommand(request.Name);

        var result = await _sender.Send(command);

        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteTeamCommand(id);

        await _sender.Send(command);

        return Ok();
    }
}
