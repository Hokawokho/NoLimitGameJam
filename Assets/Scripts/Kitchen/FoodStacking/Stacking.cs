using System;
using Enums;
using Gameplay;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class Stacking : MonoBehaviour
{


    [SerializeField] float increment1;

    [SerializeField] float increment2;

    [SerializeField] float increment3;

    private int layerCounter = 0;

    private float minRandomValue = -0.5f;

    private float maxRandomValue = +0.5f;

    private float initialX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        float initialX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            ShowFood(nlEnum.PoolObjectTypes.Cheese);
        }

        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            ShowFood(nlEnum.PoolObjectTypes.Onion);
        }
    }

    public void ShowFood(nlEnum.PoolObjectTypes ingiFromTrash)
    {
        var o = ObjectPooling.Instance.GetIngiPrefab(ingiFromTrash);
        o.gameObject.SetActive(true); 

        o.transform.position = transform.position;
        Animator animator = o.GetComponentInChildren<Animator>();
        //Animator animator = o.GetComponent<Animator>();
        //animator.ResetTrigger("stacking");

        IngiObj ingredientStats = o.GetComponent<IngiObj>();
        int h = ingredientStats.height;

        SpriteRenderer ingredientSprite = o.GetComponentInChildren<SpriteRenderer>();
        ingredientSprite.sortingOrder =layerCounter;
        
        //animator.SetTrigger("stacking");


        float number = Random.Range(minRandomValue, maxRandomValue);

        switch (h)
        {
            case (1):

                transform.position = new Vector3(initialX + number,
                                                 transform.position.y + increment1,
                                                 transform.position.z 
                                                 );
                layerCounter++;

                break;
            
            
            case (2):

                transform.position = new Vector3(transform.position.x,
                                                 transform.position.y + increment2,
                                                 transform.position.z
                                                 );
                layerCounter++;

                break;
            
            
            case (3):

                transform.position = new Vector3(transform.position.x,
                                                 transform.position.y + increment3,
                                                 transform.position.z
                                                 );
                layerCounter++;
                break;


        }


    }

    void StackFood()
    {
       
    }
}
