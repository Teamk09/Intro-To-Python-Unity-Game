using UnityEngine;

public class Bobber : MonoBehaviour
{
    public float bobbingSpeed = 0.1f;
    public float bobbingAmount = 0.1f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.position = startPosition + new Vector3(0.0f, Mathf.Sin(Time.time * bobbingSpeed) * bobbingAmount, 0.0f);
    }
}
