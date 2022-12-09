using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Schedule : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;

    [SerializeField] Transform workstation;

    Transform toilet;
    Transform fridge;
    Transform xero;
    Transform water;

    Transform target;

    float timeAtWorkstation = 15f;
    float timeAtOthers = 5f;

    float needToToilet;
    float needToEat;
    float needToXero;
    float needToDrink;

    void Awake() 
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        animator = gameObject.GetComponent<Animator>();

        timeAtWorkstation = Random.Range(4f, 25f);
    }

    void ChooseDestination()
    {
        agent.SetDestination(target.position);
    }

    void AnimateWalk()
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
