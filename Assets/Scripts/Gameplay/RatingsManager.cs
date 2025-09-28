using System;
using UnityEngine;

namespace Gameplay
{
    public class RatingsManager : MonoBehaviour
    {
        public static event Action<int> OnRatingChange;
        public static event Func<float> GetCurrentTime;
        public static event Func<(int, int)> GetFoodQuality;

        private void OnEnable()
        {
            Bell.OnBellHit += OnBellHit;
        }

        private void OnDisable()
        {
            Bell.OnBellHit -= OnBellHit;
        }

        private void OnBellHit()
        {
            var time = GetCurrentTime?.Invoke();
            var t = GetFoodQuality?.Invoke();
            Debug.Log("TIME ON BELL HIT : "+ time);
            Debug.Log($"expected quality : {t.Value.Item1}, food quality : {t.Value.Item2}");
        }
    }
}