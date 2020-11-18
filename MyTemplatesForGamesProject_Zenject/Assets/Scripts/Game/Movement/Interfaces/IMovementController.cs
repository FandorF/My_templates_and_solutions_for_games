using UnityEngine;
using System.Collections;

namespace Game.Common.Movement
{
    public interface IMovementController
    {
        IEnumerator MoveToTarget();
        IEnumerator MoveAfterInput();
        IEnumerator AIMovement();
        IEnumerator Jump();
        IEnumerator Wait(float waitingTime);
        IEnumerator RandomTimeWait(float minTime, float maxTime);

    }
}
