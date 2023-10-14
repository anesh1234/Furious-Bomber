using UnityEngine;

public class FollowB24 : MonoBehaviour
{
    public Transform B24;  // Reference to the B24 airplane
    public Vector3 offset;    // Offset position from the airplane

    private void Start()
    {
        offset = new Vector3(0.0f, 50.0f, 0.0f);
    }

    void LateUpdate()
    {
        transform.position = B24.position + offset;
    }
}
