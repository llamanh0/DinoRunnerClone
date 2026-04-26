using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool IsFinished = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        Player.OnPlayerDied += HandleGameOver;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) RestartGame();
        if (Input.GetKeyDown(KeyCode.T)) DeleteAllPlayerPrefs();
    }

    private void OnDisable()
    {
        Player.OnPlayerDied -= HandleGameOver;
    }

    private void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        IsFinished = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void HandleGameOver()
    {
        if (!IsFinished)
        {
            StartCoroutine(EndGameRoutine());
        }
    }

    private IEnumerator EndGameRoutine()
    {
        IsFinished = true;

        PlayerPrefs.Save();

        yield return new WaitForEndOfFrame();
        Time.timeScale = 0f;
    }
}