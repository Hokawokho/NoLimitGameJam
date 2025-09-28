using System;
using System.Collections.Generic;
using Gameplay;
using NUnit.Framework;
using TMPro;
using UnityEngine;

public class RateEffects : MonoBehaviour
{
    [SerializeField] private List<GameObject> effects = new List<GameObject>();
    [SerializeField] private Color[] colors;
    private void OnEnable()
    {
        RatingsManager.UpdateRating += HandlenNewRating;
    }

    private void OnDisable()
    {
        RatingsManager.UpdateRating -= HandlenNewRating;
    }

    private void HandlenNewRating(int x)
    {
        GameObject effect = GetEffect();

        var text1 = effect.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        var text2 = effect.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        
        text1.text = "+" + x.ToString();
        text2.text = "+" + x.ToString();

        if (x <= 1)
        {
            text2.color = colors[0];
        } 
        else if (x <= 3)
        {
            text2.color = colors[1];
        }
        else
        {
            text2.color = colors[2];
        }
        
        effect.SetActive(true);
    }

    private GameObject GetEffect()
    {
        for (int i = 0; i < effects.Count; i++)
        {
            if (!effects[i].activeInHierarchy)
            {
                return effects[i];
            }
        } 
        return null;
    }
}
