using System.Threading.Tasks;
using Gameplay;
using Managers;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] SoundsHolder sounds;
    [SerializeField] IngridientsDatas ingridientsDatas;
    [SerializeField] CustomerImages customerImages;

    private void Start()
    {
        SoundsManager.Instance.Init(sounds);
        RubbishManager.Instance.Init(ingridientsDatas);
        CustomersManager.Instance.Init(customerImages);
    }
}
