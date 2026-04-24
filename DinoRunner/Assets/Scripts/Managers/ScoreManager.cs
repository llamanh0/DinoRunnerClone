using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static event Action OnHundredPointsReached;
    public static event Action<int> OnScoreChanged;

    [SerializeField] private float scoreIncreaseRate = 10f;
    private float currentScore = 0;
    private int lastMilestone = 0;
    private int lastIntScore = -1;

    private void Update()
    {
        currentScore += scoreIncreaseRate * Time.deltaTime;

        int intScore = Mathf.FloorToInt(currentScore);

        if (intScore != lastIntScore)
        {   
            lastIntScore = intScore;
            OnScoreChanged?.Invoke(intScore);
        }

        if (intScore >= lastMilestone + 100)
        {
            lastMilestone += 100;
            OnHundredPointsReached?.Invoke();
        }
    }
}