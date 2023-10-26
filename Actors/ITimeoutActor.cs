using Dapr.Actors;

namespace DaprTimeout.Actors;

public interface ITimeoutActor : IActor
{
    Task Set(string state);
    Task<string> Get();
}