using UnityEngine;
public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private void OnEnable()
    {
        ScoreManager.OnHundredPointsReached += SpeedUp;
    }

    private void SpeedUp()
    {
        speed += 2f;
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.left);
    }

    private void OnDisable()
    {
        ScoreManager.OnHundredPointsReached -= SpeedUp;
    }
}