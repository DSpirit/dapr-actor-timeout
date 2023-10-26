using Dapr.Actors.Runtime;

namespace DaprTimeout.Actors;

public class TimeoutActor : Actor, ITimeoutActor
{
    public TimeoutActor(ActorHost host, IActorStateManager? stateManager = null) : base(host)
    {
        if (stateManager != null)
        {
            StateManager = stateManager;
        }
     }

    public async Task Set(string value)
    {
        await StateManager.SetStateAsync("statestore", value);
    }

    public async Task<string> Get()
    {
        Thread.Sleep(TimeSpan.FromMilliseconds(250));
        return await StateManager.GetStateAsync<string>("statestore");
    }
}