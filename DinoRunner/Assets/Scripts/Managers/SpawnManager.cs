using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstaclePrefabs;
    [SerializeField] private GameObject birdPrefab;
    [SerializeField] private Transform startPoint;

    public static float GlobalSpeed = 8f;
    [SerializeField] private float maxSpeed = 20f;

    [SerializeField] private float[] birdYPositions = new float[] { -1.5f, -0.5f, 0.8f };

    private void OnEnable()
    {
        ScoreManager.OnHundredPointsReached += SpeedUp;
        ScoreManager.OnScoreChanged += CheckUnlockables;
    }

    private void Start()
    {
        GlobalSpeed = 8f;
        StartCoroutine(SpawnRoutine());
    }

    private void SpeedUp()
    {
        if (GlobalSpeed < maxSpeed)
        {
            GlobalSpeed += 0.5f;
        }
    }

    private void CheckUnlockables(int score)
    {
        if (score >= 500 && !obstaclePrefabs.Contains(birdPrefab))
        {
            obstaclePrefabs.Add(birdPrefab);
        }
    }

    private IEnumerator SpawnRoutine()
    {
        while (!GameManager.Instance.IsFinished)
        {
            float randomDistance = Random.Range(10f, 20f);

            // t = x / v
            float spawnDelay = randomDistance / GlobalSpeed;

            yield return new WaitForSeconds(spawnDelay);

            GameObject selectedPrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];
            Vector3 spawnPos = startPoint.position;

            if (selectedPrefab == birdPrefab)
            {
                float selectedHeight = birdYPositions[Random.Range(0, birdYPositions.Length)];
                spawnPos = new Vector3(startPoint.position.x, selectedHeight, startPoint.position.z);
            }

            Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
        }
    }

    private void OnDisable()
    {
        ScoreManager.OnHundredPointsReached -= SpeedUp;
        ScoreManager.OnScoreChanged -= CheckUnlockables;
    }
}