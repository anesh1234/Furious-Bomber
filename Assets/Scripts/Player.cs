using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Multiplying by Time.deltaTime makes it move 10 meters per second instead of 10 meters per frame


    [Header("Propellers")]
    public Transform propeller1;
    public Transform propeller2;
    public Transform propeller3;
    public Transform propeller4;
    public float propellerSpeed = 1000;

    [Header("The Plane")]
    public Transform B24;
    public float forwardVelocity = 100.0f;
    public float directionSmoothing = 0.95f;
    public float rollVelocity = 40f;
    public float yawVelocity = 70f;
    public float resetSpeed = 2.0f; // Adjust this value to control the reset speed.
    public float maxRollAngle = 67.5f;
    private float rollAngle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Returns 
        float movementGiven = Input.GetAxis("Horizontal");

        if (movementGiven == 0)
        {
            ResetRoll();
        }

        TransformPlayer(movementGiven);
        RotateB24(movementGiven);
        RotatePropellers();
    }

    private void ResetRoll()
    {
        StopAllCoroutines(); // Stop any existing roll reset coroutine.
        StartCoroutine(ResetRollCoroutine());
    }

    void TransformPlayer(float movementGiven)
    {
        //Translate Player forward
        float translationZ = forwardVelocity * Time.deltaTime;
        transform.Translate(0, 0, translationZ);

        //Rotate Player around the y-axis
        Vector3 playerRotation = Vector3.zero;
        playerRotation.y = movementGiven * yawVelocity * Time.deltaTime;
        transform.Rotate(playerRotation, Space.Self);
    }



    void RotateB24(float movementGiven)
    {
        Vector3 rotationVec = Vector3.zero;
        rollAngle = -movementGiven * rollVelocity * Time.deltaTime;
        rotationVec.z = rollAngle;

        float currentRollAngle = Mathf.Abs(B24.eulerAngles.z);
        if (currentRollAngle <= maxRollAngle)
        {
            B24.Rotate(rotationVec, Space.Self);
        }
    }



    void RotatePropellers()
    {
        propeller1.localEulerAngles += Vector3.forward * propellerSpeed * Time.deltaTime;
        propeller2.localEulerAngles += Vector3.forward * propellerSpeed * Time.deltaTime;
        propeller3.localEulerAngles += Vector3.forward * propellerSpeed * Time.deltaTime;
        propeller4.localEulerAngles += Vector3.forward * propellerSpeed * Time.deltaTime;
    }


    private IEnumerator ResetRollCoroutine()
    {
        float elapsed = 0f;
        Quaternion currentRotation = B24.transform.rotation;

        while (elapsed < 1.0f)
        {
            elapsed += resetSpeed * Time.deltaTime;
            B24.rotation = Quaternion.Slerp(currentRotation, transform.rotation, elapsed);
            yield return null;
        }

        // Ensure the rotation is exactly the original rotation.
        B24.rotation = transform.rotation;
    }
}
