using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Common.Movement
{
    public interface IMovementView
    {
        float Speed { get; }

        Transform Transform { get; }
        Vector3 Position { get; }
        Rigidbody Rigidbody { get; }
        List<Transform> Waypoints { get; }

        void SetPosition(Vector3 position);
    }
}
