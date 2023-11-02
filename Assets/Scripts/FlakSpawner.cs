using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FlakSpawner : MonoBehaviour
{
    public Transform[] smallFlak;
    public Transform[] mediumFlak;
    public Transform[] bigFlak;

    public float intervalMin;
    public float intervalMax;
    public float startDelay;

    public AudioSource audioSource;

    // Timing variables
    private float timeStart;
    private float currentTime;
    private float lastTime;
    private float interval;

    Player playerObject;

    // Angles to react to
    private float lowDamageAngleMin = 0f;
    private float lowDamageAngleMax = 30f;

    private float mediumDamageAngleMin = 30.1f;
    private float mediumDamageAngleMax = 60f;

    private float highDamageAngleMin = 60.1f;


    // Start is called before the first frame update
    void Start()
    {
        timeStart = Time.time;
        playerObject = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        interval = Random.Range(intervalMin, intervalMax);
        currentTime = Time.time;
        float playerRotationY = Mathf.Abs(playerObject.transform.rotation.eulerAngles.y);

        if ((currentTime - timeStart) > startDelay)
        {
            if((playerRotationY < lowDamageAngleMax) && (playerRotationY > lowDamageAngleMin)) { FlakExplosion(3); }
            else if ((playerRotationY < mediumDamageAngleMax) && (playerRotationY > mediumDamageAngleMin)) { FlakExplosion(2); }
            else if (playerRotationY > highDamageAngleMin) { FlakExplosion(1); }
        }
    }

    void RecordTime()
    {

    }

    // low damage area = 3, high damage area = 1
    void FlakExplosion(int level)
    {
        if ((currentTime - lastTime) > interval)
        {
            Vector3 playerPosition = playerObject.transform.position;

            float lowDamageRadius = UnityEngine.Random.Range(15.1f, 20f);
            float mediumDamageRadius = UnityEngine.Random.Range(10.1f, 15f);
            float highDamageRadius = UnityEngine.Random.Range(5f, 10f);


            if (level == 3)
            {
                float spawnPointX = (playerPosition.x + Random.Range(-10, 10));
                float spawnPointY = playerPosition.y;
                float spawnPointZ = (playerPosition.z + lowDamageRadius);

                Vector3 position = new Vector3(spawnPointX, spawnPointY, spawnPointZ);

                Transform element = smallFlak[UnityEngine.Random.Range(0, smallFlak.Length)];
                Instantiate(element, position, playerObject.transform.rotation);
            }
            else if (level == 2)
            {
                float spawnPointX = (playerPosition.x + Random.Range(-10, 10));
                float spawnPointY = playerPosition.y;
                float spawnPointZ = (playerPosition.z + mediumDamageRadius);

                Vector3 position = new Vector3(spawnPointX, spawnPointY, spawnPointZ);

                Transform element = mediumFlak[UnityEngine.Random.Range(0, mediumFlak.Length)];
                Instantiate(element, position, playerObject.transform.rotation);
            }
            else if (level == 1)
            {
                float spawnPointX = (playerPosition.x + Random.Range(-5, 5));
                float spawnPointY = playerPosition.y;
                float spawnPointZ = (playerPosition.z + highDamageRadius);

                Vector3 position = new Vector3(spawnPointX, spawnPointY, spawnPointZ);

                Transform element = bigFlak[UnityEngine.Random.Range(0, bigFlak.Length)];
                Instantiate(element, position, playerObject.transform.rotation);
            }

            lastTime = Time.time;
        }
    }
}
