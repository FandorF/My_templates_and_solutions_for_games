using UnityEngine;
namespace Game.Jumping
{
    public interface IJumpingView
    {
        //Rigidbody Rigidbody { get; }

        void Jump(float jumpForce);
    }
}
