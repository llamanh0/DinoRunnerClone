using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI milestoneText;

    private float milestoneAnimTime = 0.35f;

    private void OnEnable()
    {
        ScoreManager.OnScoreChanged += UpdateScore;
        ScoreManager.OnHundredPointsReached += Milestone;
    }

    private void OnDisable()
    {
        ScoreManager.OnScoreChanged -= UpdateScore;
        ScoreManager.OnHundredPointsReached -= Milestone;
    }

    private void Milestone()
    {
        StartCoroutine(nameof(ShowMilestone));
    }

    private void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    private IEnumerator ShowMilestone()
    {
        milestoneText.text = scoreText.text;
        scoreText.gameObject.SetActive(false);
        milestoneText.gameObject.SetActive(true);

        // Animation
        yield return new WaitForSeconds(milestoneAnimTime);
        milestoneText.gameObject.SetActive(false);
        yield return new WaitForSeconds(milestoneAnimTime);
        milestoneText.gameObject.SetActive(true);
        yield return new WaitForSeconds(milestoneAnimTime);
        milestoneText.gameObject.SetActive(false);
        yield return new WaitForSeconds(milestoneAnimTime);

        milestoneText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }
}
