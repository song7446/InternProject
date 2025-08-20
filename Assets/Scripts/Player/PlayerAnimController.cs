using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    private Animator animator;

    private static int isMove = Animator.StringToHash("MoveBool");
    private static int isDead = Animator.StringToHash("DeadBool");

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnMoveAnim(Vector2 moveInput)
    {
        animator.SetBool(isMove, moveInput.magnitude > 0.5f);
    }

    public void OnDeadAnim()
    {
        animator.SetBool(isDead, true);
    }
}