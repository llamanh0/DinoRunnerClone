using UnityEngine;
public class LoopGround : MonoBehaviour
{
    readonly private float startPositionX = 10f;
    readonly private float resetThreshold = -10f;
    private void Update() => Loop();
    private void Loop()
    {
        if (transform.position.x < resetThreshold)
        {
            float tempY = transform.position.y;
            float tempZ = transform.position.z;
            Vector3 newPos = new(startPositionX, tempY, tempZ);
            transform.position = newPos;
        }
    }
}
