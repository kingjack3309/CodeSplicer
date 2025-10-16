using UnityEngine;

[System.Serializable]
public class BackgroundElement
{
    public SpriteRenderer backgroundSprite;

    [Range(0, 1)] public float xScrollSpeed;
    [Range(0, 1.5f)] public float yScrollSpeed;

    [HideInInspector] public Material spriteMaterial;
}

public class BackgroundScrolling : MonoBehaviour
{
    private const float SCROLL_MULTIPLIER = 0.01f;

    [SerializeField] private BackgroundElement[] backgroundElements;

    private void Start()
    {
        foreach (BackgroundElement element in backgroundElements)
        {
            element.spriteMaterial = element.backgroundSprite.material;
        }
    }

    private void Update()
    {
        foreach (BackgroundElement element in backgroundElements)    //X speed                                                       //Y speed
        {
            element.spriteMaterial.mainTextureOffset = new Vector2(transform.position.x * element.xScrollSpeed * SCROLL_MULTIPLIER, transform.position.y * element.yScrollSpeed * SCROLL_MULTIPLIER);
        }
    }
}
