using App.Models;
using UnityEngine;

namespace App.Domains.Spawner.View
{
    public class SpawnView : MonoBehaviour, ISpawnView
    {
        public bool IsActive
        {
            get => gameObject.activeSelf;
            set => gameObject.SetActive(value);
        }

        private float leftEdge;

        private IGameContext _gameContext;
    
        public void SetUp(IGameContext gameContext, string typeName)
        {
            gameObject.name = typeName;
            _gameContext = gameContext;
        }

        private void OnEnable()
        {
            leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
            transform.position = new Vector3(10, 0, 0);
        }

        private void Update()
        {
            if (_gameContext == null)
                return;
        
            transform.position += _gameContext.Speed * Time.deltaTime * Vector3.left;

            if (transform.position.x < leftEdge)
            {
                gameObject.SetActive(false);
            }
        }
        
        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}
