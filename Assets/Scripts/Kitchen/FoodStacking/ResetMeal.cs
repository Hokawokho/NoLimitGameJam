
using System;
using Gameplay;
using UnityEngine;

public class ResetMeal : MonoBehaviour
{
    [SerializeField] private Stacking stacking;

    private void OnEnable()
    {
        GameManager.OnServeDone += DeletMeal;
    }
    private void OnDisable()
    {
        GameManager.OnServeDone -= DeletMeal;
    }

    private void DeletMeal()
    {
        stacking.SendFood();
        GameObject shit = GameObject.FindWithTag("SHIT");
        foreach (Transform x in shit.transform)
        {
            var i = x.GetComponent<IPoolableObjects>();
            i.BackToPool();
        }
        shit.SetActive(false);
    }
    


}
