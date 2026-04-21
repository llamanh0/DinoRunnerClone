using UnityEngine;
public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private void Update() => transform.Translate(speed * Time.deltaTime * Vector3.left);
}