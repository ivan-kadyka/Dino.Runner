using System;
using Character.Model;
using UniRx;
using UnityEngine;
using Unit = Types.Unit;

namespace Character.View
{
    public class CharacterView : MonoBehaviour, ICharacterPhysics
    {
        public IObservable<Unit> Updated => _updateSubject;
        public IObservable<string> Collider => _colliderSubject;
        public bool IsGrounded => _characterComponentController.isGrounded;

        public Transform Transform => transform;

        private CharacterController _characterComponentController;

        private readonly Subject<Unit> _updateSubject = new Subject<Unit>();
        private readonly Subject<string> _colliderSubject = new Subject<string>();

        private void Awake()
        {
            _characterComponentController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            _updateSubject.OnNext(Unit.Nothing);
        }
        
        public void Move(Vector3 motion)
        {
            _characterComponentController.Move(motion);
        }

        public void OnTriggerEnter(Collider other)
        {
            _colliderSubject.OnNext(other.tag);
        }

        public void Dispose()
        {
          //  Destroy(gameObject);
        }
    }
}