using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CookTimerHandler : MonoBehaviour
{
    [SerializeField] float maxTimerValue = 10;
    [SerializeField] float minTimerValue = 5;

    public float currentTime, currentMaxTime, maxTimerDifference = 0.25f;
    bool canRunTimer;

    public static event Action OnTimeDone;
    public static event Action<float,float> UpdateTime;

    private void Awake()
    {
        currentMaxTime = maxTimerValue;
    }

    private void OnEnable()
    {
        CustomersManager.Instance.OnNewCustomerArrived += NewCustomerArrived;
    }

    private void OnDisable()
    {
        CustomersManager.Instance.OnNewCustomerArrived -= NewCustomerArrived;

    }

    private void NewCustomerArrived(int dummy)
    {
        //UpdateMaxTime();
        SetCurrentTime();
        StartCoroutine(StartTimer());
    }

    //private void Update()
    //{
    //    if (!canRunTimer) return;

    //    if(currentTime > 0)
    //    {
    //        currentTime -= Time.deltaTime;
    //    }
    //}

    IEnumerator StartTimer()
    {
        while (currentTime > 0)
        {
            currentTime--;
            UpdateTime?.Invoke(currentTime,currentMaxTime);
            yield return new WaitForSeconds(1);
        }
        OnTimeDone?.Invoke();
    }

    void SetCurrentTime()
    {
        currentTime = currentMaxTime;
    }

    public void UpdateMaxTime()
    {
        currentMaxTime -= maxTimerDifference;
    }
}

