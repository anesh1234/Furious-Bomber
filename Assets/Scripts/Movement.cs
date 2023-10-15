using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Movement : MonoBehaviour
{
    //Multiplying by Time.deltaTime makes it move 10 meters per second instead of 10 meters per frame


    [Header("Propellers")]
    public Transform propeller1;
    public Transform propeller2;
    public Transform propeller3;
    public Transform propeller4;
    public float propellerSpeed = 100;

    public Transform model;
    public float forwardVelocity = 10.0f;
    [Range(0.0f, 67.5f)]
    public float rollAngle = 30.0f;

    [Range(0.0f, 90.0f)]
    public float yawAngle = 10.0f;

    private Vector3 yawVector;

    // Start is called before the first frame update
    void Start()
    {
        //yawVector.x = 0;
        //yawVector.y = 0;
        //yawVector.z = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float movementGiven = Input.GetAxis("Horizontal");
        //transform.RotateAround(transform.position, Vector3.forward, -80 * movementGiven * Time.deltaTime);

        //yawVector.x = 0;
        //yawVector.y = -80 * movementGiven * Time.deltaTime;
        //yawVector.z = 0;

        //transform.Rotate(yawVector, Space.World);

        //model.localEulerAngles = new Vector3(currentPitchAngle, 0, currentRollAngle);

        float translationZ = forwardVelocity * Time.deltaTime;
        transform.Translate(0, 0, translationZ);

        propeller1.localEulerAngles += Vector3.forward * propellerSpeed * Time.deltaTime;
        propeller2.localEulerAngles += Vector3.forward * propellerSpeed * Time.deltaTime;
        propeller3.localEulerAngles += Vector3.forward * propellerSpeed * Time.deltaTime;
        propeller4.localEulerAngles += Vector3.forward * propellerSpeed * Time.deltaTime;
        //float translationX = Input.GetAxis("Horizontal") * forwardVelocity;

        //...
        //translationX *= ;


        //transform.Translate(translationX, 0, 0);
    }
}
