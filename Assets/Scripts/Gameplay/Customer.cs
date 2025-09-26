using Gameplay;
using UnityEngine;

public class Customer : MonoBehaviour, IPoolableObjects
{
    [SerializeField] int foddQualityExpectation;
    [SerializeField] SpriteRenderer spriteRenderer;

    private void OnValidate()
    {
        if(spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    public void Init(Sprite sprite, int foodQuality)
    {
        spriteRenderer.sprite = sprite;
        foddQualityExpectation = foodQuality;
    }



    public void Init(ObjectPooling pool)
    {
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void BackToPool()
    {
        gameObject.SetActive(false);
    }
}

