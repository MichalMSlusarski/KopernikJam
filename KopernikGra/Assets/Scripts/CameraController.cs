using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform lookAt;
    Vector3 startOffset;
    [SerializeField] bool JumpWithPlayer = false;

    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - lookAt.position;
    }

    void Update()
    {
        if(JumpWithPlayer)
        {
            transform.position = lookAt.position + startOffset;
        }
        else
        {
            transform.position = new Vector3(lookAt.position.x, 4f, lookAt.position.z) + startOffset; 
        }
    }
}
