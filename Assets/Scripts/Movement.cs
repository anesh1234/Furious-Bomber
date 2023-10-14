using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Movement : MonoBehaviour
{
    public float forwardVelocity = 10.0f;
    public float rotationVelocity = 5.0f;
    public float rotationAngle = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float movementGiven = Input.GetAxis("Horizontal");

        //  Svinger til venstre
        if (movementGiven < 0)
        {
            transform.RotateAround(transform.position, Vector3.forward, 10 * Time.deltaTime);
            transform.RotateAround(transform.position, Vector3.left, 10 * Time.deltaTime);
        }

        //  Svinger til høyre
        else if (movementGiven > 0)
        {
            transform.RotateAround(transform.position, Vector3.forward, -10 * Time.deltaTime);
            transform.RotateAround(transform.position, Vector3.right, 10 * Time.deltaTime);
        }

        //else
        //{
        //    transform.RotateAround(transform.position, Vector3.forward, -10 * Time.deltaTime);
        //}

        float translationZ = forwardVelocity;
        translationZ = translationZ * Time.deltaTime;
        transform.Translate(0, 0, translationZ);
       
        //float translationX = Input.GetAxis("Horizontal") * forwardVelocity;

        ////Make it move 10 meters per second instead of 10 meters per frame...
        //translationX *= Time.deltaTime;


        //transform.Translate(translationX, 0, 0);
    }
}
