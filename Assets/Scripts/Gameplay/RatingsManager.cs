using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class RatingsManager : MonoBehaviour
    {
        [SerializeField] int timerDonePenalty;
        public static event Action<int> OnRatingChange;
        public static event Action GameEnd;
        public static event Action<int> UpdateRating;
        public static event Action<int> UpdateOverallRating;
        public static event Func<float> GetCurrentTime;
        public static event Func<(int, int)> GetFoodQuality;

        List<int> ratings = new List<int>();

        private void OnEnable()
        {
            Bell.OnBellHit += OnBellHit;
            CookTimerHandler.OnTimeDone += OnTimerDone;
        }



        private void OnDisable()
        {
            Bell.OnBellHit -= OnBellHit;
            CookTimerHandler.OnTimeDone -= OnTimerDone;
        }

        private void Start()
        {
            for (int i = 0; i < 10; i++)
            {
                ratings.Add(5);
            }
        }
        private void OnTimerDone()
        {
            var t = GetFoodQuality?.Invoke();
            CalculateRating(0, t.Value.Item1, t.Value.Item2);
        }

        private void OnBellHit()
        {
            var time = GetCurrentTime?.Invoke();
            var t = GetFoodQuality?.Invoke();
            Debug.Log("TIME ON BELL HIT : "+ time);
            Debug.Log($"expected quality : {t.Value.Item1}, food quality : {t.Value.Item2}");
            CalculateRating(time, t.Value.Item1, t.Value.Item2);
        }

        void CalculateRating(float? time, int expectedFoodQuality, int preparedFoodQuality)
        {
            if (time <= 0)
            {
                preparedFoodQuality -= timerDonePenalty;
            }
            var rating = 5;
            if(preparedFoodQuality <= 0) rating = 0;
            else
            {
                if (preparedFoodQuality < expectedFoodQuality)
                {
                    int r = Random.Range(0, 100);
                    if (r < 25)
                    {
                        rating = 0;
                    }
                    else if (r > 25 & r < 50)
                    {
                        rating = 1;
                    }
                    else if (r > 50 & r < 75)
                    {
                        rating = 2;
                    }
                    else if (r > 75 & r < 85)
                    {
                        rating = 3;
                    }
                    else
                    {
                        rating = 4;
                    }
                }
            }

            Debug.Log($" [CalculateRating] rating: {rating}");
            UpdateRating?.Invoke(rating);
            ratings.Add(rating);

            var totalRating = 0;
            foreach (var item in ratings)
            {
                totalRating += item;
            }

            var avg = totalRating / ratings.Count;
            UpdateOverallRating?.Invoke(avg);

            if(avg <= 0) GameEnd?.Invoke(); 
        }

    }
}