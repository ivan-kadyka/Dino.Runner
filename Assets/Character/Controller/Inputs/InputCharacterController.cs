using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Character.Controller.Inputs
{
    public class InputCharacterController: MonoBehaviour, IInputCharacterController
    {
        public event Action JumpPressed;
        
        void Update()
        {
            // Check if the space key was pressed down this frame
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // If it was, invoke the Jumped event
                OnJumped();
                return;
            }
            
            // Check if we have any touch input (for mobile devices)
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0); // Get the first touch

                if (touch.phase == TouchPhase.Began) // Check if the touch has just begun
                {
                    // Call your method to handle touch input here
                    OnJumped();
                }
            }

            // Check for mouse input (for PC)
            else if (Input.GetMouseButtonDown(0)) // Check if the left mouse button was clicked
            {
                // Call your method to handle mouse input here
                OnJumped();
            }
        }

        private  void OnJumped()
        {
            // Invoke the Jumped event, using the ?. operator to only invoke it if there are any subscribers
            JumpPressed?.Invoke();
        }
    }
}