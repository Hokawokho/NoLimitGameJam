using System;
using Managers;
using UnityEngine;

namespace Helpers
{
    public class PutChildrenBackToPool : MonoBehaviour
    {
        private void OnEnable()
        {
        }

        private void OnDisable()
        {
        }

        private void BackToPool(bool b)
        {
            foreach (Transform child in transform)
            {
                
            }
        }
    }
}
