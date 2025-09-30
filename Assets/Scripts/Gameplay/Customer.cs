using System;
using Gameplay;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] int foddQualityExpectation;
    private Action callback;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Animator animator;
    
    [Header("Sprite Handle")]
    [SerializeField] Sprite[] baseSprites;
    [SerializeField] Sprite[] elroySprites;
    [SerializeField] Sprite[] girlSprites;
    [SerializeField] Sprite[] brownSprites;


    int idleHash, happyLeavingHash, madLeavingHash, spawnHash;

    public event Action OnLeavingAnimationDone;


    private void OnValidate()
    {
        if(spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>(); 
        if(animator == null) animator = GetComponent<Animator>(); 
    }

    private void OnEnable()
    {
        RatingsManager.UpdateRating += OnRatingRecieved;
    }

    private void OnDisable()
    {
        RatingsManager.UpdateRating -= OnRatingRecieved;
        
    }

    private void OnRatingRecieved(int rating)
    {
        animator.SetBool(idleHash, false);
        if(rating <= 2)
        {
            animator.SetBool(madLeavingHash, true);

            if (spriteRenderer.sprite == baseSprites[0])
            {
                // boy sprite angry
                spriteRenderer.sprite = elroySprites[0];
            }
            else if (spriteRenderer.sprite == baseSprites[1])
            {
                spriteRenderer.sprite = girlSprites[0];
            }
            else
            {
                spriteRenderer.sprite = brownSprites[0];
            }
        }
        else
        {
            animator.SetBool(happyLeavingHash, true);
            
            if (spriteRenderer.sprite == baseSprites[0])
            {
                // boy sprite angry
                spriteRenderer.sprite = elroySprites[1];
            }
            else if (spriteRenderer.sprite == baseSprites[1])
            {
                spriteRenderer.sprite = girlSprites[1];
            }
            else
            {
                spriteRenderer.sprite = brownSprites[1];
            }
        }
    }

    public void LeavingAnimationDone()
    {
        animator.SetBool(madLeavingHash, false);
        animator.SetBool(happyLeavingHash, false);
        animator.SetBool(spawnHash, true);
        OnLeavingAnimationDone?.Invoke();
    }

    private void Start()
    {
        idleHash = Animator.StringToHash("Idle");
        happyLeavingHash = Animator.StringToHash("HappyLeaving");
        madLeavingHash = Animator.StringToHash("MadLeaving");
        spawnHash = Animator.StringToHash("Spawn");
    }

    public void Init(Sprite sprite, int foodQuality, Action OnEntryAnimationDone)
    {
        spriteRenderer.sprite = sprite;
        foddQualityExpectation = foodQuality;
        callback = OnEntryAnimationDone;
    }

    public void OnEntryAnimDone()
    {
        callback?.Invoke();
        animator.SetBool(spawnHash, false);
        animator.SetBool(idleHash, true);
    }


}

