using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Reference to the player's transform
    public float smoothing = 5f; // Smoothing factor for camera movement

    private Vector3 offset; // Offset between the camera and the player

    void Start()
    {
        // Calculate the initial offset between the camera and the player
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        // Calculate the target position for the camera
        Vector3 targetPosition = target.position + offset;

        // Smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
    }
}
