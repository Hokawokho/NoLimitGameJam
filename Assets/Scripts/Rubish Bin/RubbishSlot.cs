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
    [SerializeField] private float initialStackingPitch;
    [SerializeField] private float maxPitch;
    
    private async void Start()
    {
        await Task.Delay(200);
        GetNewTrash();
    }

    public void SlotClicked()
    {
        if (rubbish.activeInHierarchy)
        {
            float  pitch = Random.Range(0.9f, 1.1f);
            initialStackingPitch += 0.05f;
            if (initialStackingPitch > maxPitch)
            {
                initialStackingPitch = maxPitch;
            }
            
            SoundsManager.Instance.PlaySound(nlEnum.GameSoundTypes.Sfx, nlEnum.GameSounds.TrashClickSuccess, pitch);
            SoundsManager.Instance.PlaySound(nlEnum.GameSoundTypes.Sfx, nlEnum.GameSounds.IngiStack, initialStackingPitch);
            rubbishBinAnimator.Play("binMovement", 0,0f);
            StartCoroutine(SendRubbish());
        }
        else
        {
            SoundsManager.Instance.PlaySound(nlEnum.GameSoundTypes.Sfx, nlEnum.GameSounds.TrashClickFail);
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
            case nlEnum.PoolObjectTypes.Cheese:
                rubbish.GetComponent<Image>().sprite = icons[0];
                break;
            
            case nlEnum.PoolObjectTypes.BadEgg:
                rubbish.GetComponent<Image>().sprite = icons[1];
                break;
            case nlEnum.PoolObjectTypes.BadFish:
                rubbish.GetComponent<Image>().sprite = icons[2];
                break;
            case nlEnum.PoolObjectTypes.BadSteak:
                rubbish.GetComponent<Image>().sprite = icons[3];
                break;
            case nlEnum.PoolObjectTypes.Beetroot:
                rubbish.GetComponent<Image>().sprite = icons[4];
                break;
            case nlEnum.PoolObjectTypes.Broccoli:
                rubbish.GetComponent<Image>().sprite = icons[5];
                break;
            case nlEnum.PoolObjectTypes.Boot:
                rubbish.GetComponent<Image>().sprite = icons[6];
                break;
            case nlEnum.PoolObjectTypes.Eyeball:
                rubbish.GetComponent<Image>().sprite = icons[7];
                break;
            case nlEnum.PoolObjectTypes.Rat:
                rubbish.GetComponent<Image>().sprite = icons[8];
                break;
            case nlEnum.PoolObjectTypes.Spaghetti:
                rubbish.GetComponent<Image>().sprite = icons[9];
                break;
            case nlEnum.PoolObjectTypes.Bun_bot:
                rubbish.GetComponent<Image>().sprite = icons[10];
                break;
            case nlEnum.PoolObjectTypes.Patty:
                rubbish.GetComponent<Image>().sprite = icons[11];
                break;
            case nlEnum.PoolObjectTypes.Bun_top:
                rubbish.GetComponent<Image>().sprite = icons[12];
                break;
            case nlEnum.PoolObjectTypes.Donut:
                rubbish.GetComponent<Image>().sprite = icons[13];
                break;
            case nlEnum.PoolObjectTypes.Pizza:
                rubbish.GetComponent<Image>().sprite = icons[14];
                break;
            case nlEnum.PoolObjectTypes.Tomatoe:
                rubbish.GetComponent<Image>().sprite = icons[15];
                break;
            case nlEnum.PoolObjectTypes.Lettuce:
                rubbish.GetComponent<Image>().sprite = icons[16];
                break;
            case nlEnum.PoolObjectTypes.Bone:
                print("BONE");
                rubbish.GetComponent<Image>().sprite = icons[17];
                break;
        }
    }
}
