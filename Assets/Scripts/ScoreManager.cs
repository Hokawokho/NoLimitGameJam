using System;
using Gameplay;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [Header("References")]
    
    [SerializeField] private Image foodQualityBar;
    [SerializeField] private RectTransform expectedScoreLabel;
    
    [Header("Settings")]
    
    [SerializeField] private Color goodColor;
    [SerializeField] private Color badColor;
    
    [SerializeField] private int mealScore;
    [SerializeField] private int expectedScore;
    [SerializeField] private int foodQualityBarSpeed;
    [SerializeField] private int MAXSCORE;
    private const float MIN_POSITION = -196.38f;
    private const float MAX_POSITION = 196.38f;
    
    private void OnEnable()
    {
        RatingsManager.GetFoodQuality += RatingsManagerOnGetFoodQuality;
        CustomersManager.OnNewCustomerArrived += HandleNewCustomer;
    }

    private void HandleNewCustomer(int obj)
    {
        expectedScore = obj;
        
    }

    private void OnDisable()
    {
        RatingsManager.GetFoodQuality -= RatingsManagerOnGetFoodQuality;
        CustomersManager.OnNewCustomerArrived -= HandleNewCustomer;
    }

    private (int, int) RatingsManagerOnGetFoodQuality()
    {
        return (expectedScore, mealScore);
    }

    private void Update()
    {
        foodQualityBar.fillAmount = Mathf.Lerp(foodQualityBar.fillAmount, mealScore / (float)MAXSCORE, foodQualityBarSpeed * Time.deltaTime);

        foodQualityBar.color = mealScore < expectedScore ? badColor : goodColor;
        UpdateExpectedScoreLabelPosition();
    }

    public void AddMealScore(int newScore)
    {
        mealScore += newScore;

        if (mealScore < 0)
        {
            mealScore = 0;
        }
    }
    
    private void UpdateExpectedScoreLabelPosition()
    {
        float normalizedScore = expectedScore / (float)MAXSCORE; 
        float targetPosition = Mathf.Lerp(MIN_POSITION, MAX_POSITION, normalizedScore);

        // Current position
        Vector2 currentPosition = expectedScoreLabel.anchoredPosition;

        // Smoothly move towards target
        float smoothSpeed = 5f;
        float newX = Mathf.Lerp(currentPosition.x, targetPosition, Time.deltaTime * smoothSpeed);

        // Apply new position
        expectedScoreLabel.anchoredPosition = new Vector2(newX, currentPosition.y);
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
    public int GetMaxScore()
    {
        return MAXSCORE;
    }
}
