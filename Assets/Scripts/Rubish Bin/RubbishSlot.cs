using System.Collections;
using Enums;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class RubbishSlot : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private GameObject rubbish;
    [SerializeField] private SlotFill fill;
    [SerializeField] private ScoreManager scoreManager;
    
    [Header("Settings")]

    [SerializeField] private float timer;

    private void Start()
    {
        GetNewTrash();
    }

    public void SlotClicked()
    {
        if (rubbish.activeInHierarchy)
        {
            //SoundsManager.Instance.PlaySound(nlEnum.GameSoundTypes.Sfx, nlEnum.GameSounds.TrashClick);
            StartCoroutine(SendRubbish());
        }
    }

    private IEnumerator SendRubbish()
    {
        rubbish.SetActive(false);
        fill.gameObject.SetActive(true);
        
        scoreManager.AddMealScore((int)Random.Range(-10, 10));
        
        yield return new WaitForSeconds(timer);
        GetNewTrash();
    }

    private void GetNewTrash()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value);

        rubbish.GetComponent<Image>().color = randomColor;

        rubbish.SetActive(true);
    }

}
