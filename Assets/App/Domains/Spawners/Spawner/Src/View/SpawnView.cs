using App.GameCore;
using UnityEngine;

namespace App.Spawner
{
    public class SpawnView : MonoBehaviour, ISpawnView
    {
        public bool IsActive
        {
            get => gameObject.activeSelf;
            set => gameObject.SetActive(value);
        }

        private float _leftEdge;
        
        private Rigidbody _rigidbody;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            
            _rigidbody.mass = 1f; // Adjust as necessary
            _rigidbody.drag = 0.5f; // Adjust to simulate resistance
            _rigidbody.angularDrag = 0.5f; // Prevent excessive spinning
            _rigidbody.interpolation = RigidbodyInterpolation.Interpolate; // For smoother movement
            _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic; // For fast-moving objects

            // Locking axes
            _rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;

        }

        private IGameContext _gameContext;
        private IColliderObjectObserver _objectObserver;
        private IObject _spawnObject;
    
        public void SetUp(
            IGameContext gameContext,
            IColliderObjectObserver objectObserver,
            IObject spawnObject)
        {
            _objectObserver = objectObserver;
            _gameContext = gameContext;
            _spawnObject = spawnObject;
        }

        private void OnEnable()
        {
            if (Camera.main != null) 
                _leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
            
            transform.position = new Vector3(10, 0, 0);
        }
        
        void FixedUpdate()
        {
            if (_gameContext == null)
                return;
            
            _rigidbody.MovePosition(_rigidbody.position + Vector3.left * (_gameContext.Speed * Time.fixedDeltaTime));

            if (_rigidbody.position.x < _leftEdge)
            {
                gameObject.SetActive(false);
            }
        }
        
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                OnColliderHandle();
                
                if (_objectObserver != null)
                    _objectObserver.OnNext(_spawnObject);
            }
        }

        protected virtual void OnColliderHandle()
        {
        }
        
        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}
