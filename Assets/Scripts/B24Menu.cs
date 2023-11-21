using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B24Menu : MonoBehaviour
{
    [Header("Propellers")]
    public Transform propeller1;
    public Transform propeller2;
    public Transform propeller3;
    public Transform propeller4;
    public float propellerSpeed = 1000;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotatePropellers();
    }

    void RotatePropellers()
    {
        propeller1.localEulerAngles += Vector3.forward * propellerSpeed * Time.deltaTime;
        propeller2.localEulerAngles += Vector3.forward * propellerSpeed * Time.deltaTime;
        propeller3.localEulerAngles += Vector3.forward * propellerSpeed * Time.deltaTime;
        propeller4.localEulerAngles += Vector3.forward * propellerSpeed * Time.deltaTime;
    }
}
