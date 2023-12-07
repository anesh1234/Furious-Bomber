using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    public GameEvent gameEvent;
    Quaternion finalRotation = new Quaternion(0.0538468696f, -0.569891691f, 0.0319797136f, 0.819329798f);
    Vector3 finalPosition = new Vector3(9.5f, 3.02999997f, -5.9000001f);
    public float movingSpeed = 0.5f;

    //private bool isLoading;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    isLoading = false;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (isLoading == true)
    //    {
    //        MoveCamera();
    //    }
    //}

    public void MoveCamera()
    {
        StartCoroutine(MoveCameraCoroutine());
    }

    private IEnumerator MoveCameraCoroutine()
    {
        float elapsed = 0f;
        Quaternion currentRotation = transform.rotation;
        Vector3 currentPosition = transform.position;

        while (elapsed < 3f)
        {
            elapsed += movingSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(currentRotation, finalRotation, elapsed);
            transform.position = Vector3.Slerp(currentPosition, finalPosition, elapsed);
            yield return null;
        }

        // Ensure the rotation is exactly the original rotation.
        transform.position = finalPosition;
        transform.rotation = finalRotation;
    }
}
