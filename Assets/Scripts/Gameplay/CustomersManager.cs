using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using Managers;
using UnityEngine;

public class CustomersManager : GenericSingleton<CustomersManager>
{
    CustomerImages customerImages;

    int minFoodExpectation = 50;
    int maxFoodExpectation = 100;

    float finalScale = 10;

    public event Action<int> OnNewCustomerArrived;
    public Customer customer;
    private async void Start()
    {
        await Task.Delay(100);
        SpawnCustomer();
        
    }
    private void OnEnable()
    {
        CookTimerHandler.OnTimeDone += OnTimerDone;
    }

    private void OnDisable()
    {

        CookTimerHandler.OnTimeDone -= OnTimerDone;
    }

    private void OnTimerDone()
    {
        SwitchCustomer();
    }

    public void Init(CustomerImages customerImages)
    {
        this.customerImages = customerImages;
    }

    private void SpawnCustomer()
    {
        var t = customer.transform;
        t.localScale = Vector3.zero;

        var ex = UnityEngine.Random.Range(minFoodExpectation, maxFoodExpectation);
        customer.Init(customerImages.GetCustomerImage(), ex);
        customer.gameObject.SetActive(true);
        t.DOScale(finalScale, 0.2f);

        OnNewCustomerArrived?.Invoke(ex);
    }

    private void SwitchCustomer()
    {
        customer.gameObject.SetActive(false);
        SpawnCustomer();
    }
}

