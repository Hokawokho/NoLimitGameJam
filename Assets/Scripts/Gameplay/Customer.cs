using Gameplay;
using UnityEngine;

public class Customer : MonoBehaviour, IPoolableObjects
{
    [SerializeField] float foddQualityExpectation;
    [SerializeField] SpriteRenderer spriteRenderer;

    private void OnValidate()
    {
        if(spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    public void SetCustomerImage(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
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

