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
    }

    private void OnDisable()
    {
        RatingsManager.GetFoodQuality -= RatingsManagerOnGetFoodQuality;
    }

    private (int, int) RatingsManagerOnGetFoodQuality()
    {
        return (expectedScore, mealScore);
    }

    private void Start()
    {
        UpdateExpectedScoreLabelPosition();
    }

    private void Update()
    {
        foodQualityBar.fillAmount = Mathf.Lerp(foodQualityBar.fillAmount, mealScore / (float)MAXSCORE, foodQualityBarSpeed * Time.deltaTime);

        foodQualityBar.color = mealScore < expectedScore ? badColor : goodColor;
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
        float normalizedScore = expectedScore / (float)MAXSCORE; // Convert to 0-1 range
        float targetPosition = Mathf.Lerp(MIN_POSITION, MAX_POSITION, normalizedScore);
        
        // Update the X position of the label
        Vector3 currentPosition = expectedScoreLabel.anchoredPosition;
        expectedScoreLabel.anchoredPosition = new Vector2(targetPosition, currentPosition.y);
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
