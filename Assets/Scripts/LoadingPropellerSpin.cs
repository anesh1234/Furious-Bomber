using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingPropellerSpin : MonoBehaviour
{
    public Image propeller;
    public float turnSpeed;

    private Vector3 rotation;

    private void Start()
    {
        rotation = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        rotation.z = turnSpeed * Time.deltaTime;
        propeller.rectTransform.Rotate(rotation, Space.Self);
    }
}
