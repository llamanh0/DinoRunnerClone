using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static event Action OnHundredPointsReached;
    public static event Action<int> OnScoreChanged;
    public static event Action<int> OnHIChanged;

    [SerializeField] private float scoreIncreaseRate = 10f;
    private float currentScore = 0;
    private int lastMilestone = 0;
    private int lastIntScore = -1;
    private int highScore = 0;
    private bool firstTime = false;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (highScore != 0)
        {
            OnHIChanged?.Invoke(highScore);
        }
        else
        {
            firstTime = true;
        }
    }

    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsFinished) return;

        currentScore += scoreIncreaseRate * Time.deltaTime;

        int intScore = Mathf.FloorToInt(currentScore);

        if (intScore != lastIntScore)
        {   
            lastIntScore = intScore;
            OnScoreChanged?.Invoke(intScore);
            CheckHighScore(intScore);
        }

        if (intScore >= lastMilestone + 100)
        {
            lastMilestone += 100;
            OnHundredPointsReached?.Invoke();
        }
    }

    private void CheckHighScore(int score)
    {
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);

            if (firstTime) return;
            OnHIChanged?.Invoke(highScore);
        }
    }    
}