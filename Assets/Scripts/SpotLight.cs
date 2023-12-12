using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpotLight : MonoBehaviour
{
    public int constantYValue;
    public Transform bombDropPoint;

    void Update()
    {
        transform.position = new Vector3(bombDropPoint.position.x, constantYValue, bombDropPoint.position.z);
    }
}
