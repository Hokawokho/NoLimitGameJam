using System;
using Gameplay;
using UnityEngine;
using UnityEngine.Pool;

public enum IngiType
{
    Onion
}

[CreateAssetMenu(fileName = "Ingredient", menuName = "Scriptable Objects/Ingredient")]
public class Ingredient : ScriptableObject
{
    public int value, height;

    public Texture2D sprite;
    public IngiType ingiType;

    internal void SetParent(object value)
    {
        throw new NotImplementedException();
    }
}
