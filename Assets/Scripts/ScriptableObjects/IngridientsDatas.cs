using System;
using System.Collections.Generic;
using Enums;
using UnityEngine;

[Serializable]
public class IngridientData
{
    public int value;
    public nlEnum.PoolObjectTypes inrgidientType;

    public IngridientData() { }
    public IngridientData(int value, nlEnum.PoolObjectTypes inrgidientType) { 
        this.value = value;
        this.inrgidientType = inrgidientType;
    }
}

[CreateAssetMenu(fileName = "IngridientsDatas", menuName = "Scriptable Objects/IngridientsDatas")]

public class IngridientsDatas : ScriptableObject
{
    [SerializeField]List<IngridientData> data = new List<IngridientData>();

    public IngridientData GetIngridient()
    {
        var rand = data[UnityEngine.Random.Range(0, data.Count)];
        return new IngridientData(rand.value, rand.inrgidientType) { }; ;
    }
}
