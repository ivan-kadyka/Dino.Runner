using System;
using App.GameCore;
using UniRx;
using UnityEngine;

namespace App.Character.Dino
{
    internal class CharacterView : MonoBehaviour, ICharacterPhysics, ICharacterSounds
    {
        public IObservable<float> Updated => _updateSubject;
        public IObservable<IObject> Collider => _colliderSubject;
        public bool IsGrounded => _characterComponentController.isGrounded;
        
        [SerializeField]
        private AudioClip _coinSound;
        
        [SerializeField]
        private AudioClip _dieSound;
        
        [SerializeField]
        private AudioClip _jumpSound;

        public Transform Transform => transform;

        private UnityEngine.CharacterController _characterComponentController;
        private AudioSource _audioSource;

        private readonly Subject<float> _updateSubject = new Subject<float>();
        private readonly Subject<IObject> _colliderSubject = new Subject<IObject>();

        private void Awake()
        {
            _characterComponentController = GetComponent<UnityEngine.CharacterController>();
            _audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            _updateSubject.OnNext(Time.deltaTime);
        }
        
        public void Move(Vector3 motion)
        {
            _characterComponentController.Move(motion);
        }

        public void Play(CharacterSoundType soundType)
        {
            switch (soundType)
            {
                case CharacterSoundType.Jump:
                    _audioSource.PlayOneShot(_jumpSound);
                    break;
                case CharacterSoundType.Idle:
                    _audioSource.PlayOneShot(_dieSound);
                    break;
                case CharacterSoundType.Effect:
                    _audioSource.PlayOneShot(_coinSound);
                    break;
            }
        }

        public void OnTriggerEnter(Collider other)
        {
           var objectView =  other.GetComponent<IObjectView>();

           if (objectView != null && objectView.Object != null)
           {
               _colliderSubject.OnNext(objectView.Object);
           }
        }
    }
}