using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Script for Enemy in start Menu*/
//only for Docorations hahaha || decoration*
//
public class ZombieDocoration : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {        
        animator.Play("Idle");
    }
}
