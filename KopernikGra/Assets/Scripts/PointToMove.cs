using UnityEngine;
using UnityEngine.AI;

public class PointToMove : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    [SerializeField] Camera camera;
        
    void Start() 
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
        
    void Update() 
    {
        if (Input.GetMouseButton(0)) 
        {
            RaycastHit hit;
                
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit, 10000)) 
            {
                //Debug.Log("hit " + hit.transform.name);
                agent.destination = hit.point;
            }
        }

        Animate();
    }

    void Animate()
    {
        if (agent.velocity.magnitude > .1f)
        {
            animator.SetBool("IsIdle", false);
        }
        else
        {
            animator.SetBool("IsIdle", true);
        }
    }  
}
