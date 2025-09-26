using System.Threading.Tasks;
using Gameplay;
using Managers;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //async void Start()
    //{
    //    //await Task.Delay(500);
    //    ////var o = ObjectPooling.Instance.GetIngiPrefab();
    //    ////o.gameObject.SetActive(true);   
    //}
    [SerializeField] SoundsHolder sounds;

    private void Start()
    {
        SoundsManager.Instance.Init(sounds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
