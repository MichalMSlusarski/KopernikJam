using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float zoomSpeed = 10;
    [SerializeField] float maxZoomOut = 50;
    [SerializeField] float mazZoomIn = 10;

    void Update()
    {
        Zoom();
    }

    void Zoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        cam.orthographicSize -= scroll * zoomSpeed;
    }
}
