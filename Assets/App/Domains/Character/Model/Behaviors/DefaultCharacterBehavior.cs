using System.Threading;
using Character.Model;
using Cysharp.Threading.Tasks;
using Types;
using UniRx;
using UnityEngine;

namespace App.Domains.Character.Model.Behaviors
{
    public class DefaultCharacterBehavior : DisposableBase, ICharacterBehavior
    {
        private readonly ICharacterPhysics _physics;
        private readonly CharacterSettings _settings;
        private Vector3 _motion;
        
        private readonly CompositeDisposable _disposable = new CompositeDisposable();
        
        private UniTaskCompletionSource _jumpingTaskCompletionSource = new UniTaskCompletionSource();

        public DefaultCharacterBehavior(ICharacterPhysics physics, CharacterSettings settings)
        {
            _physics = physics;
            _settings = settings;
        }

        public void Update(float deltaTime)
        {
            if (_physics.IsGrounded)
                return;
            
            _motion += _settings.Gravity * Time.deltaTime * Vector3.down;
            _physics.Move(_motion * Time.deltaTime);
        }


        public bool CanExecute()
        {
            return _physics.IsGrounded;
        }

        public UniTask Execute(CancellationToken token = default)
        {
            _motion = Vector3.up * _settings.JumpForce;
            
            _motion += _settings.Gravity * Time.deltaTime * Vector3.down;
            _physics.Move(_motion * Time.deltaTime);
            
            //
            // ExecuteJumping();

            return UniTask.CompletedTask;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _disposable.Dispose();
            }
        }

       
    }
}