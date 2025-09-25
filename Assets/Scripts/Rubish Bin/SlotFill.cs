using UnityEngine;
using UnityEngine.UI;

public class SlotFill : MonoBehaviour
{
    [SerializeField] private Image fill;
    private float maxValue;
    private void Start()
    {
        maxValue = fill.fillAmount;
    }
    private void Update()
    {
        fill.fillAmount -= Time.deltaTime;

        if (fill.fillAmount <= 0 )
        {
            fill.fillAmount = maxValue;
            gameObject.SetActive( false );
        }
    }
}
