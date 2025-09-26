using System;
using System.Collections.Generic;
using Enums;
using UnityEngine;

[Serializable]
public class IngridientData
{
    public float value;
    public Texture2D texture;
    public nlEnum.PoolObjectTypes inrgidientType;
}

[CreateAssetMenu(fileName = "IngridientsDatas", menuName = "Scriptable Objects/IngridientsDatas")]

public class IngridientsDatas : ScriptableObject
{
    [SerializeField]List<IngridientData> data = new List<IngridientData>();

    public IngridientData GetIngridient()
    {
        return data[UnityEngine.Random.Range(0, data.Count)];
    }
}
