using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private const string IS_ON_AIR = "isOnAir";
    private const string IS_CROUCHING = "isCrouching";

    [SerializeField] private Animator _animator;

    private void Update()
    {
        _animator.SetBool(IS_ON_AIR, !Player.Instance.isGrounded);
        _animator.SetBool(IS_CROUCHING, Player.Instance.isCrouching);
    }
}
