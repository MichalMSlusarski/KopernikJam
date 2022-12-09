using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAgent : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    [SerializeField] Transform target;

    void Awake() 
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        animator = gameObject.GetComponent<Animator>();
    }

    void Update() 
    {
        agent.SetDestination(target.position);
        Animate();
    }

    void Animate()
    {
        if (agent.velocity.magnitude > .15f)
        {
            animator.SetBool("IsIdle", false);
        }
        else
        {
            animator.SetBool("IsIdle", true);
        }
    }
}
