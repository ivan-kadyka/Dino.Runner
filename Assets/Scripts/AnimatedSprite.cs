using UnityEngine;
using UnityEngine.U2D;

[RequireComponent(typeof(SpriteRenderer))]
public class AnimatedSprite : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private int frame;

    [SerializeField] 
    private SpriteAtlas _spriteAtlas;
    
    [SerializeField] 
    private string[] _spriteNames;

    private Sprite[] _sprites;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        _sprites = new Sprite[_spriteNames.Length];
        
        for (int i = 0; i < _spriteNames.Length; i++)
        {
            _sprites[i] = _spriteAtlas.GetSprite(_spriteNames[i]);
        }
    }

    private void OnEnable()
    {
        Invoke(nameof(Animate), 0f);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Animate()
    {
        frame++;

        if (frame >= _sprites.Length) {
            frame = 0;
        }

        if (frame >= 0 && frame < _sprites.Length) {
            spriteRenderer.sprite = _sprites[frame];
        }

        Invoke(nameof(Animate), 1f / 5);
    }

}
