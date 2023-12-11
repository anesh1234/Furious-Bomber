using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Multiplying by Time.deltaTime makes it move 10 meters per second instead of 10 meters per frame


    [Header("Propellers")]
    public Transform propeller1;
    public Transform propeller2;
    public Transform propeller3;
    public Transform propeller4;
    public float propellerSpeed = 1000;

    [Header("Bombs")]
    public GameObject bombPrefab;
    public Transform bombDropPoint;

    [Header("The Plane")]
    public Transform B24;
    public float forwardVelocity = 100.0f;
    public float directionSmoothing = 0.95f;
    public float rollVelocity = 40f;
    public float yawVelocity = 70f;
    public float resetSpeed = 2.0f; // Adjust this value to control the reset speed.
    public float maxRollAngle = 67.5f;
    
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip[] explosionClips;
    public AudioClip bombFalling;

    [Header("Health, Ammo & Points")]
    public float maxHealth;
    public int ammunition;
    public Image healthBar;
    public TextMeshProUGUI ammoField;
    public int points;

    [Header("Map Bounds")]
    public float mapEndZ;
    public int maxBoundPosX;
    public int maxBoundNegX;
    public int warnBoundPosX;
    public int warnBoundNegX;

    [Header("Special Screeens")]
    public GameObject deathScreen;
    public GameObject warningScreen;
    public GameObject playerHud;

    private float rollAngle;
    private float currentHealth;
    private float timeOfDeath;
    public GameController controller;

    // States
    private bool isDead;
    private bool isFinished;
    private int oneTime = 0;




    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        ammoField.text = ammunition.ToString();
        isDead = false;
        isFinished = false;
        points = 0;
    }


    // Update is called once per frame
    void Update()
    {
        // Kan ha 3 tilstander: vanlig, død og ferdig
        if (isDead) { Death(); }
        else if (isFinished) { Finished(); }
        else
        {
            float movementGiven = Input.GetAxis("Horizontal");

            if (movementGiven == 0)
            {
                ResetRoll();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DropBomb();
            }

            TransformPlayer(movementGiven);
            RotateB24(movementGiven);
            RotatePropellers();
            BoundCheck();
        }
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
        rollAngle = -movementGiven * rollVelocity * Time.deltaTime;
        Vector3 rotationVec = new Vector3(0,0,rollAngle);

        float currentRollAngle = Mathf.Abs(B24.transform.rotation.eulerAngles.z);

        if (currentRollAngle <= maxRollAngle || currentRollAngle >= 360 - maxRollAngle)
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

    private void DropBomb()
    {
        if (ammunition > 0)
        {
            Instantiate(bombPrefab, bombDropPoint.position, bombDropPoint.rotation);
            ammunition--;
            ammoField.text = ammunition.ToString();
            audioSource.PlayOneShot(bombFalling, 4);
        }
    }

    public void PlayAudio(AudioClip clip, float volume)
    {
        audioSource.PlayOneShot(clip, volume);
    }

    public void PlayGroundExplosion()
    {
        AudioClip clip = explosionClips[UnityEngine.Random.Range(0, explosionClips.Length)];
        audioSource.PlayOneShot(clip);
    }

    public void InflictDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / 100;

        if (currentHealth <= 0)
        {
            isDead = true;
        }
    }

    public void AddPoints(int incomingPoints)
    {
        points += incomingPoints;
    }

    void Death()
    {
        if (oneTime < 1)
        {
            StartCoroutine(WaitPostDeath());
            playerHud.SetActive(false);
            timeOfDeath = Time.time;
            oneTime = 1;
        }

        float translationY = forwardVelocity * Time.deltaTime;
        transform.Translate(0, -translationY, translationY/2);

        if (B24.rotation.eulerAngles.x < 90)
        {
            rollAngle = rollVelocity * Time.deltaTime;
            Vector3 rotationVec = new Vector3(rollAngle, 0, 0);
            B24.Rotate(rotationVec, Space.Self);
        }

        if (Time.time - timeOfDeath >= 5)
        {
            Destroy(gameObject);
        }
    }

    void Finished()
    {
        AudioSource[] audiosources = GetComponents<AudioSource>();
        for (int i = 0; i < audiosources.Length; i++)
        {
            audiosources[i].mute = true;
        }
    }

    void BoundCheck()
    {
        float xPos = transform.position.x;
        float zPos = transform.position.z;

        if (zPos >= mapEndZ)
        {
            controller.OnPlayerFinished(points);

            isFinished = true;
        }
        else if (xPos >= maxBoundPosX || xPos <= maxBoundNegX) 
        { 
            isDead = true;
        }

        if (((xPos >= warnBoundPosX) && (xPos < maxBoundPosX)) || ((xPos <= warnBoundNegX) && (xPos > maxBoundNegX))) 
        { 
            warningScreen.SetActive(true); 
        }
        else { warningScreen.SetActive(false); }
    }

    private IEnumerator WaitPostDeath()
    {
        yield return new WaitForSeconds(3);
        deathScreen.SetActive(true);
    }
}
