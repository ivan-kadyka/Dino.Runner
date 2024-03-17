using Controllers.Spawner.Obstacle.Model;
using UnityEngine;

public class Obstacle : MonoBehaviour, IObstacleView
{
    public bool IsActive
    {
        get => gameObject.activeSelf;
        set => gameObject.SetActive(value);
    }
    
    private float leftEdge;

    private void OnEnable()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
        transform.position = new Vector3(10, 0, 0);
    }

    private void Update()
    {
        transform.position += GameManager.Instance.gameSpeed * Time.deltaTime * Vector3.left;

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
