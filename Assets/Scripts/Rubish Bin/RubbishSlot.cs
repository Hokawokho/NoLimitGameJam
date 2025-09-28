using System;
using System.Collections;
using System.Threading.Tasks;
using Enums;
using Managers;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class RubbishSlot : MonoBehaviour
{
    [Header("Icons")]
    
    [SerializeField] private Sprite[] icons;
    
    [Header("References")]

    [SerializeField] private GameObject rubbish;
    [SerializeField] private SlotFill fill;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private Stacking stacking;
    [SerializeField] private Animator rubbishBinAnimator;
    
    [Header("Settings")]

    [SerializeField] private float timer;
    [SerializeField] private int foodvalue;
    [SerializeField] private nlEnum.PoolObjectTypes inrgidientType;
    
    private async void Start()
    {
        await Task.Delay(200);
        GetNewTrash();
    }

    public void SlotClicked()
    {
        if (rubbish.activeInHierarchy)
        {
            //SoundsManager.Instance.PlaySound(nlEnum.GameSoundTypes.Sfx, nlEnum.GameSounds.TrashClickSuccess);
            rubbishBinAnimator.Play("binMovement", 0,0f);
            StartCoroutine(SendRubbish());
        }
        else
        {
            //SoundsManager.Instance.PlaySound(nlEnum.GameSoundTypes.Sfx, nlEnum.GameSounds.TrashClickFail);
        }
    }

    private IEnumerator SendRubbish()
    {
        rubbish.SetActive(false);
        fill.gameObject.SetActive(true);
        
        stacking.ShowFood(inrgidientType);
        scoreManager.AddMealScore(foodvalue);
        
        yield return new WaitForSeconds(timer);
        GetNewTrash();
    }

    private void GetNewTrash()
    {
        IngridientData ingridientData = RubbishManager.Instance.GetIngredient();
        
        foodvalue = ingridientData.value;
        inrgidientType = ingridientData.inrgidientType;
        
        SetImage(inrgidientType);
        rubbish.SetActive(true);
    }

    private void SetImage(nlEnum.PoolObjectTypes food)
    {
        switch (food)
        {
            case nlEnum.PoolObjectTypes.Patty:
                rubbish.GetComponent<Image>().sprite = icons[0];
                break;
            
            case nlEnum.PoolObjectTypes.Cheese:
                rubbish.GetComponent<Image>().sprite = icons[1];
                break;
        }
    }
}
