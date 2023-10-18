using System;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Transform[] explosionArray;


    private void Awake()
    {
        Vector3 rotationVec = Vector3.zero;
        rotationVec.x = 90;
        transform.Rotate(rotationVec, Space.World);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.GetContact(0);
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 position = contact.point;

        Transform element = explosionArray[UnityEngine.Random.Range(0, explosionArray.Length)];
        Instantiate(element, position, rotation);

        Destroy(gameObject);
    }
}