using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Enums;
using Gameplay;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class Stacking : MonoBehaviour
{


    [SerializeField] float increment1;

    [SerializeField] float smallIngi2;

    [SerializeField] float botBun3;

    [SerializeField] float badSteak4;

    [SerializeField] float eyeball5;    
    
    
    [SerializeField] float cheese6;

    [SerializeField] float boot7;

    private int layerCounter = 0;

    [SerializeField] float minRandomValue;

    [SerializeField] float maxRandomValue;

    private float initialX = 7.73f;

    private nlEnum.PoolObjectTypes[] ingredients;
    private int currentIndex = 0;

    private List<IngiObj> fullMeal = new List<IngiObj>();

    private Vector3 initialPosition;


    //[SerializeField] GameObject fullMeal;
    



    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        //float initialX = transform.position.x;

        initialPosition = transform.position;

        ingredients = (nlEnum.PoolObjectTypes[])System.Enum.GetValues(typeof(nlEnum.PoolObjectTypes));
        
        Debug.Log("Ingrediente actual: " + ingredients[currentIndex]);

        

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            ShowFood(ingredients[currentIndex]);
        }

        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            ShowFood(nlEnum.PoolObjectTypes.Boot);
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            CycleIngredient();
        }

        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            SendFood();
        }
    }

    private void CycleIngredient()
    {
        currentIndex++;

        if (currentIndex >= ingredients.Length)
        {
            currentIndex = 0;
        }
        Debug.Log("Ingrediente actual: " + ingredients[currentIndex]);
         
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
        ingredientSprite.sortingOrder = layerCounter;

        fullMeal.Add(o);
        //PositionConstraint positionConstraint = o.GetComponent<PositionConstraint>();

        //ConstraintSource source = new ConstraintSource();
        ////source.sourceTransform = fullMeal.transform;
        //source.sourceTransform = transform;
        //source.weight = 1.0f; 


        //positionConstraint.AddSource(source);

        //positionConstraint.locked = true;
        //positionConstraint.constraintActive = true;


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

                transform.position = new Vector3(initialX,
                                                 transform.position.y + smallIngi2,
                                                 transform.position.z
                                                 );
                layerCounter++;

                break;


            case (3):

                transform.position = new Vector3(initialX,
                                                 transform.position.y + botBun3,
                                                 transform.position.z
                                                 );
                layerCounter++;
                break;

            
            case (4):

                transform.position = new Vector3(initialX,
                                                 transform.position.y + badSteak4,
                                                 transform.position.z
                                                 );
                layerCounter++;
                break;

            case (5):

                transform.position = new Vector3(initialX,
                                                 transform.position.y + eyeball5,
                                                 transform.position.z
                                                 );
                layerCounter++;
                break; 
            
            case (6):

                transform.position = new Vector3(initialX,
                                                 transform.position.y + cheese6,
                                                 transform.position.z
                                                 );
                layerCounter++;
                break;

            case (7):

                transform.position = new Vector3(initialX,
                                                 transform.position.y + boot7,
                                                 transform.position.z
                                                 );
                layerCounter++;
                break;


        }


    }

    public void SendFood()
    {
        GameObject parentMeal = new GameObject();
        parentMeal.tag = "SHIT";
        parentMeal.transform.position = transform.position;


        foreach (IngiObj ingi in fullMeal)
        {
            ingi.transform.parent = parentMeal.transform;
        }

        this.transform.position = initialPosition;
    }
}
