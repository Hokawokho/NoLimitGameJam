using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using Gameplay;
using Managers;
using UnityEngine;

public class CustomersManager : MonoBehaviour
{
    CustomerImages customerImages;

    int minFoodExpectation = 50;
    int maxFoodExpectation = 100;

    float finalScale = 10;

    public static event Action<int> OnNewCustomerArrived;
    public Customer customer;
    private async void Start()
    {
        await Task.Delay(100);
        SpawnCustomer();
        
    }
    private void OnEnable()
    {
        customer.OnLeavingAnimationDone += SwitchCustomer;
        GameManager.CustomersManagerInit += Init;
    }

    private void OnDisable()
    {

        customer.OnLeavingAnimationDone -= SwitchCustomer;
        GameManager.CustomersManagerInit -= Init;
    }


    public void Init(CustomerImages customerImages)
    {
        this.customerImages = customerImages;
    }

    private void SpawnCustomer()
    {
        var t = customer.transform;

        var ex = UnityEngine.Random.Range(minFoodExpectation, maxFoodExpectation);

        customer.Init(customerImages.GetCustomerImage(), ex , () =>
        {
            OnNewCustomerArrived?.Invoke(ex);
        });
        //customer.gameObject.SetActive(true);
    }

    private void SwitchCustomer()
    {
        //customer.gameObject.SetActive(false);
        SpawnCustomer();
    }
}

