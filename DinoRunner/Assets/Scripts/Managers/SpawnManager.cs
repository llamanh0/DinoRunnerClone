using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
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
            while (!GameManager.Instance.isFinished)
            {
                float randomDistance = Random.Range(10f, 20f);

                // t = x / v
                float spawnDelay = randomDistance / GlobalSpeed;

                yield return new WaitForSeconds(spawnDelay);

                GameObject selectedPrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];

                float dynamicHeight;
                if (selectedPrefab == birdPrefab)
                {
                    dynamicHeight = birdYPositions[Random.Range(0, birdYPositions.Length)];
                }
                else
                {
                    dynamicHeight = selectedPrefab.gameObject.transform.localScale.y / 2;
                }
                Vector3 spawnPos = new(startPoint.position.x, dynamicHeight, startPoint.position.z);

                Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
            }
        }

        private void OnDisable()
        {
            ScoreManager.OnHundredPointsReached -= SpeedUp;
            ScoreManager.OnScoreChanged -= CheckUnlockables;
        }
    }
}