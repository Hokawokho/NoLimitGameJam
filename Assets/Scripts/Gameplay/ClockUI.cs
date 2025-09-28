using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class ClockUI : MonoBehaviour
    {
        [SerializeField] Image circularFill;
        [SerializeField] RectTransform clockHand;

        private void OnValidate()
        {
            if(circularFill == null) circularFill = GetComponent<Image>();
        }

        private void OnEnable()
        {
            CookTimerHandler.UpdateTime += UpdateTime;
            CookTimerHandler.OnTimeDone += OnTimeDone;
        }

        private void OnDisable()
        {
            CookTimerHandler.UpdateTime -= UpdateTime;
            CookTimerHandler.OnTimeDone -= OnTimeDone;

        }

        private void OnTimeDone()
        {
            circularFill.fillAmount = 1;
        }

        private void UpdateTime(float cuurentTime, float maxTime)
        {
            // Debug.Log("TimeUpdated : " + (cuurentTime , cuurentTime / maxTime));
            var nv = cuurentTime / maxTime;
            //circularFill.fillAmount = lerp;

            circularFill.fillAmount = nv ;  
        
            var newRot = Quaternion.Euler(0,0, -(nv * 360)); 
            clockHand.rotation = newRot;
        }

    }
}