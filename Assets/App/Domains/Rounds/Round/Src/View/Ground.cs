using App.GameCore;
using App.Round;
using UnityEngine;

//TODO: need optimize resources via tiles and small sprites. current Groud.png is too big :(

[RequireComponent(typeof(MeshRenderer))]
internal class Ground : MonoBehaviour, IRoundView
{
    private MeshRenderer _meshRenderer;
    private IGameContext _gameContext;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    
    public void SetUp(IGameContext gameContext)
    {
        _gameContext = gameContext;
    }
    
    private void Update()
    {
        if (_gameContext == null)
            return;
        
        float localSpeed = _gameContext.Speed / transform.localScale.x;
        _meshRenderer.material.mainTextureOffset += localSpeed * Time.deltaTime * Vector2.right;
    }

    public void Dispose()
    {
        Destroy(gameObject);
    }
}
