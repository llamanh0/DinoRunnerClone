using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private void Update()
    {
        if (GameManager.Instance.IsFinished) return;

        transform.Translate(SpawnManager.GlobalSpeed * Time.deltaTime * Vector3.left);

        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }
}