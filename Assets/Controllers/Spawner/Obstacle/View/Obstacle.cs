using Controllers.Spawner.Obstacle.Model;
using UnityEngine;

public class Obstacle : MonoBehaviour, IObstacleView
{
    private float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
        transform.position = new Vector3(10, 0, 0);
    }

    private void Update()
    {
        transform.position += GameManager.Instance.gameSpeed * Time.deltaTime * Vector3.left;

        if (transform.position.x < leftEdge)
        {
            Dispose();
        }
    }

    public void Dispose()
    {
        Destroy(gameObject);
    }
}
