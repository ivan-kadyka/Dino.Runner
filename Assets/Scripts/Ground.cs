using Controllers;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Ground : MonoBehaviour, IView
{
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        float speed = GameManager.Instance.gameSpeed / transform.localScale.x;
        meshRenderer.material.mainTextureOffset += speed * Time.deltaTime * Vector2.right;
    }

    public void Dispose()
    {
        Destroy(gameObject);
    }
}
