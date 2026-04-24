using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private bool isFinished = false;

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

    private void HandleGameOver()
    {
        if (!isFinished)
        {
            StartCoroutine(EndGameRoutine());
        }
    }

    private IEnumerator EndGameRoutine()
    {
        isFinished = true;

        yield return new WaitForEndOfFrame();
        Time.timeScale = 0f;
    }
}