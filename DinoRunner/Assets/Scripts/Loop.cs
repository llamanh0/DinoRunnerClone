using UnityEngine;

public class Loop : MonoBehaviour
{
    [SerializeField] private float _baseLenght = 8.203128f;

    private void FixedUpdate()
    {
        if(transform.localPosition.x < -_baseLenght)
        {
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        gameObject.transform.localPosition = Vector3.zero;
    }

}
