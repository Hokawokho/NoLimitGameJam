using System;
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            ShowFood();
        }
    }

    public void ShowFood()
    {
        var o = ObjectPooling.Instance.GetIngiPrefab();
        o.gameObject.SetActive(true); 

        o.transform.position = transform.position;
        
        IngiObj ingredientStats = o.GetComponent<IngiObj>();
        int h = ingredientStats.height;

        SpriteRenderer ingredientSprite = o.GetComponent<SpriteRenderer>();
        ingredientSprite.sortingOrder =layerCounter;


        float number = Random.Range(-1.0f, 3.0f);

        switch (h)
        {
            case (1):

                transform.position = new Vector3(transform.position.x + number,
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
