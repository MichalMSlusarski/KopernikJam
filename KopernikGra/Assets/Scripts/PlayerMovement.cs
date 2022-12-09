using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 10f;

    Rigidbody m_RigidBody;
    Vector3 m_Vector3;
    Animator animator;

    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update() 
    {
        if (m_RigidBody.velocity.magnitude > .15f)
        {
            animator.SetBool("IsIdle", false);
        }
        else
        {
            animator.SetBool("IsIdle", true);
        }
    }

    void FixedUpdate()
    {
        m_Vector3 = new Vector3(Input.GetAxis("Horizontal") * speed, m_RigidBody.velocity.y, Input.GetAxis("Vertical") * speed);
        transform.LookAt(transform.position + new Vector3(m_Vector3.x, 0, m_Vector3.z));  
        m_RigidBody.velocity = m_Vector3;
    }
}
