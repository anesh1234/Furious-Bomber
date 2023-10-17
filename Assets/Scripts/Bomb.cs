using UnityEngine;

public class Bomb : MonoBehaviour
{

    public float gravity = 9.81f;
    public Transform Map;

    private float timeSinceDrop;
    private Vector3 velocity;
    private bool bombHasLanded = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceDrop += Time.deltaTime;

        velocity -= transform.up * gravity * Time.deltaTime;

        float currentHeight = transform.position.magnitude;

        if (currentHeight <= Map.eulerAngles.y)
        {
            bombHasLanded = true;
        }
        else
        {
            transform.position += velocity * Time.deltaTime;
        }
    }
}
