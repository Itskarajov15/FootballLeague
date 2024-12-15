using FootballLeague.Application.Rankings;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FootballLeague.API.Controllers.Ranking;

[ApiController]
[Route("api/ranking")]
public class RankingController : ControllerBase
{
    private readonly ISender _sender;

    public RankingController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new GetRankingQuery();

        var result = await _sender.Send(query);

        return Ok(result);
    }
}
