using Game.Common.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Common.Movement
{
    public class MovementView : MonoBehaviour, IMovementView
    {
        public float Speed => _speed;
        public Transform Transform  => transform;  
        public Vector3 Position => transform.position;
        public Rigidbody Rigidbody => _rigidbody;

        public List<Transform> Waypoints => _waipoints;

        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private List<Transform> _waipoints;

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }
    }
}
