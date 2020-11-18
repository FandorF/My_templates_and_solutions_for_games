using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Jumping
{
    public class JumpingView : IJumpingView
    {
        //public Rigidbody Rigidbody => _rigidbody;

        [SerializeField] private Rigidbody _rigidbody;

        public void Jump(float jumpForce)
        {
            _rigidbody.AddForce(new Vector3(0, jumpForce, 0));
        }
    }
}
