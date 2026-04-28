using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public const float OFFSET = -1;
    public Transform target;
    public float smoothingSpeed = 0.125f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 endPosition = target.position;
        endPosition.z += OFFSET;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, endPosition, smoothingSpeed);
        transform.position = smoothPosition;
    }
}
