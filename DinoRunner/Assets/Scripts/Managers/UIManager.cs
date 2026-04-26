using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI milestoneText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Button retryButton;

    private float milestoneAnimTime = 0.35f;

    private void OnEnable()
    {
        Player.OnPlayerDied += ShowGameOverUI;
        ScoreManager.OnScoreChanged += UpdateScore;
        ScoreManager.OnHIChanged += UpdateHI;
        ScoreManager.OnHundredPointsReached += Milestone;
    }

    private void Start()
    {
        retryButton.onClick.RemoveAllListeners();
        retryButton.onClick.AddListener(() => GameManager.Instance.RestartGame());
    }

    private void OnDisable()
    {
        Player.OnPlayerDied -= ShowGameOverUI;
        ScoreManager.OnScoreChanged -= UpdateScore;
        ScoreManager.OnHIChanged -= UpdateHI;
        ScoreManager.OnHundredPointsReached -= Milestone;
    }

    private void ShowGameOverUI()
    {
        gameOverPanel.SetActive(true);
    }

    private void UpdateHI(int highScore)
    {
        highScoreText.text = "HI " + highScore.ToString();
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
