using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform mainCameraTransform;

    private void Start()
    {
        // Find the main camera in the scene and store its transform
        mainCameraTransform = Camera.main.transform;

        // Optional: If you need to specify a different camera,
        // you can make the variable public and assign it in the Inspector.
        // public Transform targetCamera;
        // mainCameraTransform = targetCamera ?? Camera.main.transform;
    }

    private void LateUpdate()
    {
        // Make the UI element look at the camera position
        // The negative Z-axis is typically considered "forward" for Unity UI elements in world space.
        transform.LookAt(transform.position + mainCameraTransform.rotation * Vector3.forward,
                         mainCameraTransform.rotation * Vector3.up);
    }
}