using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private Transform startPoint;

    private void Start()
    {
        StartCoroutine(nameof(SpawnRoutine));
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            float randomDelay = Random.Range(1.5f, 3f);
            yield return new WaitForSeconds(randomDelay);
            Instantiate(obstaclePrefab, startPoint);
        }
    }
}
