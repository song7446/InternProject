using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimController : MonoBehaviour
{
    private Animator animator;
    
    private static int isDead = Animator.StringToHash("DaedBool");

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    public void OnDeadAnim()
    {
        animator.SetBool(isDead, true);
    }
}
