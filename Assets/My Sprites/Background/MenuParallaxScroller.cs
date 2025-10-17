using UnityEngine;
using UnityEngine.UI;

public class MenuParallaxScroller : MonoBehaviour
{
    [SerializeField] private RawImage _img;
    [SerializeField] private float _x, _y;

    private void Update()
    {
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x * 0.3f, _y * 0.3f) * Time.deltaTime, _img.uvRect.size);
    }
}