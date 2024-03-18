using UnityEngine;

namespace Controllers.Spawner.Coins.View
{
    public class CoinView : MonoBehaviour, ICoinView
    {
        public bool IsActive
        {
            get => gameObject.activeSelf;
            set => gameObject.SetActive(value);
        }

        public void UpdateSpeed(float speed)
        {
            _speed = speed;
        }

        private float leftEdge;
        private float _speed;

        private void OnEnable()
        {
            leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
            transform.position = new Vector3(10, 0, 0);
        }

        private void Update()
        {
            transform.position += _speed * Time.deltaTime * Vector3.left;

            if (transform.position.x < leftEdge)
            {
                SetActive(false);
            }
        }

        public void SetActive(bool enable)
        {
            gameObject.SetActive(enable);
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}