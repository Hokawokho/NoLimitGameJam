using System;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    [SerializeField] Image circularFill;

    private void OnEnable()
    {
        CookTimerHandler.UpdateTime += UpdateTime;   
    }

    private void OnDisable()
    {
        CookTimerHandler.UpdateTime -= UpdateTime;

    }

    private void UpdateTime(float cuurentTime)
    {
        Debug.Log("TimeUpdated : " + cuurentTime);
    }

}

