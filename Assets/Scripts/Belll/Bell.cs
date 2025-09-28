using UnityEngine;

public class Bell : MonoBehaviour
{
    [SerializeField] private Animator bellAnimator;

    public void BellHit()
    {
        bellAnimator.Play("Bell",0,0f);
    }
}
