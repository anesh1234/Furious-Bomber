using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

namespace Klareh
{
    public class ZeroController : MonoBehaviour
    {
        [Header("Animation")]
        public bool Engine;
        public bool Wheels;
        private Animator _animator;

        [Header("The Plane")]
        public Transform Zero;
        public float forwardVelocity = 100.0f;
        public float directionSmoothing = 0.95f;
        public float rollVelocity = 40f;
        public float yawVelocity = 70f;
        public float resetSpeed = 2.0f; // Adjust this value to control the reset speed.
        public float maxRollAngle = 67.5f;
        private float rollAngle;

        [Header("B24")]
        public Transform b24;

        void Start()
        {
            Engine = true;
            Wheels = true;
            _animator = GetComponent<Animator>();
        }

        void Update()
        {
            if (Engine)
            _animator.SetBool("EngineState", true);
            else
            _animator.SetBool("EngineState", false);

            if (Wheels)
            _animator.SetBool("WheelsState", true);
            else
            _animator.SetBool("WheelsState", false);





            float movementGiven = 0;//currently fly straight forward       Input.GetAxis("Horizontal"); --Controlled by player input


            // The angle variable now contains the angle between where Zero is looking and b24 on the horizontal plane
            Debug.DrawLine(Zero.position, b24.position, Color.red);
            Debug.DrawLine(Zero.position, Zero.position + Zero.forward * 50, Color.blue);

            Vector3 line1Direction = b24.position - Zero.position;
            Vector3 line2Direction = Zero.position - Zero.position + Zero.forward * 50;

            float dotProduct = Vector3.Dot(line1Direction.normalized, line2Direction.normalized);
            float angleInRadians = Mathf.Acos(dotProduct);
            float angleInDegrees = angleInRadians * Mathf.Rad2Deg;

            Debug.Log("Angle between Zero and b24: " + angleInDegrees);












            if (movementGiven == 0)
            {
                ResetRoll();
            }


            TransformPlayer(movementGiven);
            RotateZero(movementGiven);

        }

        private void ResetRoll()
        {
            StopAllCoroutines(); // Stop any existing roll reset coroutine.
            StartCoroutine(ResetRollCoroutine());
        }


        private IEnumerator ResetRollCoroutine()
        {
            float elapsed = 0f;
            Quaternion currentRotation = Zero.transform.rotation;

            while (elapsed < 1.0f)
            {
                elapsed += resetSpeed * Time.deltaTime;
                Zero.rotation = Quaternion.Slerp(currentRotation, transform.rotation, elapsed);
                yield return null;
            }

            // Ensure the rotation is exactly the original rotation.
            Zero.rotation = transform.rotation;
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

        void RotateZero(float movementGiven)
        {
            rollAngle = -movementGiven * rollVelocity * Time.deltaTime;
            Vector3 rotationVec = new Vector3(0, 0, rollAngle);

            float currentRollAngle = Mathf.Abs(Zero.transform.rotation.eulerAngles.z);

            if (currentRollAngle <= maxRollAngle || currentRollAngle >= 360 - maxRollAngle)
            {
                Zero.Rotate(rotationVec, Space.Self);
            }
        }
    }
}
