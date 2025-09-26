using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("References")]
    
    [SerializeField] private TextMeshProUGUI scoreText;
    
    [Header("Settings")]
    
    [SerializeField] private int mealScore;
    [SerializeField] private int expectedScore;

    private void Update()
    {
        scoreText.text = mealScore.ToString();
    }

    public void AddMealScore(int newScore)
    {
        mealScore += newScore;

        if (mealScore < 0)
        {
            mealScore = 0;
        }
    }

    public int GetMealScore()
    {
        return mealScore;
    }
    
    public void DeliverMeal(int score)
    {
        expectedScore = score;

        if (mealScore >= expectedScore)
        {
            GoodMeal();
        }
        else
        {
            BadMeal();
        }
    }

    private void GoodMeal()
    {
        // Win State
        mealScore = 0;
        expectedScore = 0;
    }
    private void BadMeal()
    {
        // Lose State
    }
}
