// <copyright file="IActorFactory.cs" company="Carl Zeiss Vision International GmbH">
//     Copyright (c) Carl Zeiss Vision International GmbH. All rights reserved.
//     THIS IS UNPUBLISHED PROPRIETARY SOURCE CODE OF Carl Zeiss Vision International GmbH.
//     The copyright notice does not evidence any actual or intended publication.
// </copyright>

using Dapr.Actors;

namespace DaprTimeout.Services;

public interface IActorFactory<out TActor> where TActor : IActor
{
    TActor CreateActor(string persistentId);
}