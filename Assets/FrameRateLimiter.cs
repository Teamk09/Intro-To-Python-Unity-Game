using UnityEngine;

public class FrameRateLimiter : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60; // Set the target framerate to 60fps
    }
}
