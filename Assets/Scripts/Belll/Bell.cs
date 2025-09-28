using System;
using UnityEngine;

public class Bell : MonoBehaviour
{
    [SerializeField] private Animator bellAnimator;

    public static event Action OnBellHit;

    public void BellHit()
    {
        bellAnimator.Play("Bell",0,0f);
        OnBellHit?.Invoke();    
    }
}
