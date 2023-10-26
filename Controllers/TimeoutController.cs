using Dapr.Actors;
using DaprTimeout.Actors;
using DaprTimeout.Services;
using Microsoft.AspNetCore.Mvc;

namespace DaprTimeout.Controllers;

[ApiController]
[Route("api/timeout/[action]")]
public class TimeoutController : ControllerBase
{
    private const string ActorId = "orderid";
    private readonly IActorFactory<ITimeoutActor> _actorFactory;

    public TimeoutController(IActorFactory<ITimeoutActor> timeoutActorFactory)
    {
        _actorFactory = timeoutActorFactory;
    }

    [HttpGet]
    public async Task<IActionResult> Status()
    {
        return new OkObjectResult("ok");
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var actor = _actorFactory.CreateActor(ActorId);

        var result = await actor.Get();

        return new OkObjectResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(
        [FromBody] string content)
    {
        var actor = _actorFactory.CreateActor(ActorId);

        await actor.Set(content);

        return new OkResult();
    }
}
