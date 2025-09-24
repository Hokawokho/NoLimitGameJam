using System;
using Enums;
using Gameplay;
using UnityEngine;

public class IngiObj : MonoBehaviour, IPoolableObjects
{

    [SerializeField] int value;
    [SerializeField] int height;

    [SerializeField] nlEnum.PoolObjectTypes ingiName;


    ObjectPooling pool;
    public void BackToPool()
    {
        pool.AddBackToList(this,ingiName);
    }

    public void Init(ObjectPooling pool)
    {
        this.pool = pool;
        //gameObject.SetActive(true);
    }

    internal void SetParent(Transform value)
    {
        transform.parent = value;   
    }




}
