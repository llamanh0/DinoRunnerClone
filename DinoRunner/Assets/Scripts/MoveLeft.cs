using Managers;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private bool _isParallax = false;

    private void FixedUpdate()
    {
        if (GameManager.Instance.isFinished) return;

        transform.Translate(SpawnManager.GlobalSpeed * Time.deltaTime * Vector3.left * _moveSpeed);

        float gameObjectTransformX = _isParallax ? transform.localPosition.x : transform.position.x;

        if (gameObjectTransformX < -15f && !_isParallax)
        {
            Destroy(gameObject);
        }
    }
}