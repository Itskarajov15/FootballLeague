using FootballLeague.API.Controllers.Matches.Requests;
using FootballLeague.Application.Matches.AddMatch;
using FootballLeague.Application.Matches.DeleteMatch;
using FootballLeague.Application.Matches.GetAllMatches;
using FootballLeague.Application.Matches.GetMatchById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FootballLeague.API.Controllers.Matches;

[ApiController]
[Route("api/matches")]
public class MatchController : ControllerBase
{
    private readonly ISender _sender;

    public MatchController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllMatchesQuery();

        var result = await _sender.Send(query);

        return Ok(result);
    }

    [HttpGet("getById/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetMatchByIdQuery(id);

        var result = await _sender.Send(query);

        return Ok(result);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] AddMatchRequest request)
    {
        var command = new AddMatchCommand(request.Team1Id, request.Team2Id, request.Team1Score, request.Team2Score, request.MatchDate);

        var result = await _sender.Send(command);

        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteMatchCommand(id);

        await _sender.Send(command);

        return Ok();
    }
}
