using UnityEngine;

public class Stacking : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public string poolTag;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Ingredient.CreateInstance

        }
    }

    public void ShowFood()
    {
        //GameObject ingredient = ObjectPooler.Instance.SpawnFromPool()

    }

    void StackFood()
    {
        //if(Ingredient.height = 1)
    }
}
