using System;
using UnityEngine;

namespace Character.Controller.Inputs
{
    public class InputCharacterController: MonoBehaviour, IInputCharacterController
    {
        public event Action JumpPressed;

        private void Update()
        {
            // Check if the space key was pressed down this frame
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // If it was, invoke the Jumped event
                OnJumped();
            }
        }

        protected virtual void OnJumped()
        {
            // Invoke the Jumped event, using the ?. operator to only invoke it if there are any subscribers
            JumpPressed?.Invoke();
        }
    }
}