using System;
using System.Collections;
using UnityEngine;

namespace Gameplay
{
    public class CookTimerHandler : MonoBehaviour
    {
        [SerializeField] float maxTimerValue = 10;
        [SerializeField] float minTimerValue = 5;

        public float currentTime, currentMaxTime, maxTimerDifference = 0.25f;
        bool canRunTimer;
        private Coroutine timer;

        public static event Action OnTimeDone;
        public static event Action<float,float> UpdateTime;
        
        private void Awake()
        {
            currentMaxTime = maxTimerValue;
        }

        private void OnEnable()
        {
            CustomersManager.Instance.OnNewCustomerArrived += NewCustomerArrived;
            Bell.OnBellHit += StopTimer;
            RatingsManager.GetCurrentTime += OnGetCurrentTime;
        }


        private void OnDisable()
        {
            CustomersManager.Instance.OnNewCustomerArrived -= NewCustomerArrived;
            Bell.OnBellHit -= StopTimer;
            RatingsManager.GetCurrentTime -= OnGetCurrentTime;

        }
        private float OnGetCurrentTime()
        {
            return currentTime;
        }

        private void NewCustomerArrived(int dummy)
        {
            //UpdateMaxTime();
            SetCurrentTime();
            timer = StartCoroutine(StartTimer());
        }

        //private void Update()
        //{
        //    if (!canRunTimer) return;

        //    if(currentTime > 0)
        //    {
        //        currentTime -= Time.deltaTime;
        //    }
        //}

        IEnumerator StartTimer()
        {
            while (currentTime > 0)
            {
                currentTime--;
                UpdateTime?.Invoke(currentTime,currentMaxTime);
                yield return new WaitForSeconds(1);
            }
            OnTimeDone?.Invoke();
        }

        public void StopTimer()
        {
            StopCoroutine(timer);
        }

        void SetCurrentTime()
        {
            currentTime = currentMaxTime;
        }

        public void UpdateMaxTime()
        {
            currentMaxTime -= maxTimerDifference;
        }
    }
}

