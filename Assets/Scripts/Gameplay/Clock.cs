using System;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    [SerializeField] Image circularFill;

    private void OnValidate()
    {
        if(circularFill == null) circularFill = GetComponent<Image>();
    }

    private void OnEnable()
    {
        CookTimerHandler.UpdateTime += UpdateTime;
        CookTimerHandler.OnTimeDone += OnTimeDone;
    }

    private void OnDisable()
    {
        CookTimerHandler.UpdateTime -= UpdateTime;
        CookTimerHandler.OnTimeDone -= OnTimeDone;

    }

    private void OnTimeDone()
    {
        circularFill.fillAmount = 1;
    }

    private void UpdateTime(float cuurentTime, float maxTime)
    {
        Debug.Log("TimeUpdated : " + (cuurentTime , cuurentTime / maxTime));
        var nv = cuurentTime / maxTime;
        //circularFill.fillAmount = lerp;

        circularFill.fillAmount = nv ;  
    }

}

