using System;
using System.Threading.Tasks;
using Gameplay;
using Managers;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] SoundsHolder sounds;
    [SerializeField] IngridientsDatas ingridientsDatas;
    [SerializeField] CustomerImages customerImages;

    public static event Action OnServeDone;
    public static event Action<CustomerImages> CustomersManagerInit;

    private void OnEnable()
    {
        Bell.OnBellHit += ServeDone;
        CookTimerHandler.OnTimeDone += ServeDone;
    }
    private void OnDisable()
    {
        Bell.OnBellHit -= ServeDone;
        CookTimerHandler.OnTimeDone -= ServeDone;
    }

    private void Start()
    {
        SoundsManager.Instance.Init(sounds);
        RubbishManager.Instance.Init(ingridientsDatas);
        CustomersManagerInit?.Invoke(customerImages);
    }
    private void ServeDone()
    {
        OnServeDone?.Invoke();  
    }
}
