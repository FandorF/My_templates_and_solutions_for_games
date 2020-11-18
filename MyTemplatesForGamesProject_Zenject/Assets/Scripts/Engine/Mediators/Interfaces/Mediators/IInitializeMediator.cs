using System;

namespace Engine.Mediators
{
    interface IInitializeMediator
    {
        event Action OnDone;
    }
}
