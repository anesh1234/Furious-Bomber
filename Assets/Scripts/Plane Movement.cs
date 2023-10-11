using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public float forwardVelocity = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float rotation = Input.GetAxis("Vertical") * 0.010f;
        rotation *= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(rotation, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(-rotation, 0, 0);
        }

        //transform.Rotate(rotationLeft, 0, 0);
        //transform.Rotate(rotationRight, 0, 0);

        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        // Flyet har fucka koordinatsystem, så flyets y-akse = unity's x-akse

        float translationY = Input.GetAxis("Horizontal") * forwardVelocity;
        float translationX = forwardVelocity;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translationY *= Time.deltaTime;
        translationX *= Time.deltaTime;
        // Move translation along the object's x-axis
        transform.Translate(0, -translationY, 0);

        // Move translation along the object's z-axis
        transform.Translate(-translationX, 0, 0);
    }
}
