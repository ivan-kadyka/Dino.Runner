using Controllers.Round.View;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Ground : MonoBehaviour, IRoundView
{
    private MeshRenderer _meshRenderer;
    private float _speed;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    
    public void SetUp(float speed)
    {
        _speed = speed;
    }
    
    private void Update()
    {
        if (_speed == 0)
            return;
        
        float localSpeed = _speed / transform.localScale.x;
        _meshRenderer.material.mainTextureOffset += localSpeed * Time.deltaTime * Vector2.right;
    }

    public void Dispose()
    {
        Destroy(gameObject);
    }
}
