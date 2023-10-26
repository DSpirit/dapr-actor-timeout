using Dapr.Actors;
using Dapr.Actors.Client;

namespace DaprTimeout.Services
{

    public class ActorFactory<TActorService, TActorConcrete> : IActorFactory<TActorService>
        where TActorService : IActor
        where TActorConcrete : TActorService
    {
        public TActorService CreateActor(string persistentId)
        {
            var actorIds = new ActorId(persistentId);
            var actorTypeName = typeof(TActorConcrete).Name;

            return ActorProxy.Create<TActorService>(actorIds, actorTypeName, new ActorProxyOptions {
                RequestTimeout = TimeSpan.FromSeconds(10)
            });
        }
    }
}