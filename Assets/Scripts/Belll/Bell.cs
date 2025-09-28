using System; 
using Enums;
using Managers;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bell : MonoBehaviour
{
    [SerializeField] private Animator bellAnimator;
    [SerializeField] private Stacking stacking;
    public static event Action OnBellHit;

    public void BellHit()
    {
        bellAnimator.Play("Bell",0,0f);
        float  pitch = Random.Range(1f, 1.12f);
        SoundsManager.Instance.PlaySound(nlEnum.GameSoundTypes.Sfx, nlEnum.GameSounds.Bell, pitch);
        
        OnBellHit?.Invoke();    
        
        stacking.SendFood();
        GameObject shit = GameObject.FindWithTag("SHIT");
        Destroy(shit);
    }
}
