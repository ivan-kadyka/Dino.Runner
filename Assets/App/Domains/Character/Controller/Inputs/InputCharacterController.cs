using System;
using UniRx;
using UnityEngine;
using Unit = Infra.Observable.Src.Unit;

namespace App.Domains.Character.Controller.Inputs
{
    public class InputCharacterController: MonoBehaviour, IInputCharacterController
    {
        public IObservable<Unit> JumpPressed => _jumpSubject;

        private readonly Subject<Unit> _jumpSubject = new Subject<Unit>();
        
        void Update()
        { 
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    OnJumped();
                }
            }
            else if (Input.GetMouseButtonDown(0)) 
            {
                OnJumped();
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                OnJumped();
            }
        }

        private  void OnJumped()
        {
            _jumpSubject.OnNext(Unit.Nothing);
        }
    }
}