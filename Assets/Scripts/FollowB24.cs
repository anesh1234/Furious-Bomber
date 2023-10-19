using UnityEngine;

public class FollowB24 : MonoBehaviour
{
    public Transform B24;     // Reference to the B24 airplane

    public float xOffset = 0f;
    public float yOffset = 50.0f;
    public float zOffset = 0f;

    public Vector3 offset;    // Offset position from the airplane


    private void Start()
    {
        offset = new Vector3(xOffset, yOffset, zOffset);
    }

    void LateUpdate()
    {
        transform.position = B24.position + offset;
    }
}
