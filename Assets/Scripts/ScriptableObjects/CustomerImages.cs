using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CustomerImages", menuName = "Scriptable Objects/CustomerImages")]
public class CustomerImages : ScriptableObject
{
    [SerializeField] List<Sprite> customerImages = new List<Sprite>();

    public Sprite GetCustomerImage()
    {
        return customerImages[Random.Range(0,customerImages.Count)];
    }
}
