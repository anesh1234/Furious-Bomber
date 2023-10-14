//using UnityEngine;

//public class Player : MonoBehaviour
//{

//    public event System.Action<Package> packageDropped;

//    [Header("Movement")]
//    public float turnSpeedInTopDownView;
//    public float turnSpeedInBehindView;
//    float forwardSpeed = 10.0f;
//    public float speedSmoothing = 0.1f;

//    [HideInInspector]
//    public float totalTurnAngle;
//    public float smoothRollTime;
//    public float rollAngle;
//    public float turnSmoothTime;

//    [Header("Graphics")]
//    public Transform model;

//    //[Header("Package Delivery")]
//    //public Package packagePrefab;
//    //public Transform packageDropPoint;


//    GameCamera gameCamera;
//    float smoothedTurnSpeed;
//    float turnSmoothV;
//    float rollSmoothV;

//    public float currentRollAngle { get; private set; }
//    public float turnInput { get; private set; }

//    float baseTargetSpeed;


//    void Awake()
//    {
//        gameCamera = FindObjectOfType<GameCamera>();
//    }

//    void Update()
//    {
//        HandleMovement();
//        UpdateGraphics();
//    }

//    public void UpdateMovementInput(Vector2 moveInput)
//    {
//        // Turning
//        turnInput = moveInput.x;

//    }

//    void HandleMovement()
//    {
//        // Turn
//        float turnSpeed = (gameCamera.topDownMode) ? turnSpeedInTopDownView : turnSpeedInBehindView;
//        smoothedTurnSpeed = Mathf.SmoothDamp(smoothedTurnSpeed, turnInput * turnSpeed, ref turnSmoothV, turnSmoothTime);
//        float turnAmount = smoothedTurnSpeed * Time.deltaTime;
//        totalTurnAngle += turnAmount;


//        // Update speed
//        UpdatePosition(forwardSpeed);
//        UpdateRotation(turnAmount);

//        float targetRoll = turnInput * rollAngle;
//        currentRollAngle = Mathf.SmoothDampAngle(currentRollAngle, targetRoll, ref rollSmoothV, smoothRollTime);
//    }


//    void UpdatePosition(float forwardSpeed)
//    {
//        // Update position
//        Vector3 newPos = transform.position + transform.forward * forwardSpeed * Time.deltaTime;
//        newPos = new Vector3(newPos.x, 0, newPos.z);
//        transform.position = newPos;
//    }

//    void UpdateRotation(float turnAmount)
//    {
//        transform.RotateAround(transform.position, Vector3.up, turnAmount);
//    }


//    void UpdateGraphics()
//    {
//        // Set pitch/roll rotation
//        SetPlaneRotation();

//        // Rotate propeller
//        //propeller.localEulerAngles += Vector3.forward * propellerSpeed * Time.deltaTime;

//    }

//    void SetPlaneRotation()
//    {
//        model.localEulerAngles = new Vector3(0, 0, currentRollAngle);
//    }


//    // ---- Public functions ----

//    //public Package DropPackage()
//    //{
//    //    Package package = Instantiate(packagePrefab, packageDropPoint.position, packageDropPoint.rotation);
//    //    package.Init(worldLookup);
//    //    packageDropped?.Invoke(package);
//    //    return package;
//    //}