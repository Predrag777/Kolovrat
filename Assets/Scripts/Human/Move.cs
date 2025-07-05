using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform cameraTransform;
    private float mouseSensivity = 100f;
    private Animator animator;
    private Rigidbody rb;

    private float xRotate = 0f;
    private Vector3 movement;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        if (animator == null)
            Debug.LogError("There is no animator");
        if (rb == null)
            Debug.LogError("There is no Rigidbody");
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        RotationHandler();
        ProcessInput();
        AnimateMovement();
    }

    void FixedUpdate()
    {
        MoveHandler();
    }

    void RotationHandler()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

        xRotate -= mouseY;
        xRotate = Mathf.Clamp(xRotate, -45f, 75f);

        cameraTransform.localRotation = Quaternion.Euler(xRotate, 0f, 0f);
    }

    void ProcessInput()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        movement = new Vector3(h, 0, v).normalized;
    }

    void MoveHandler()
    {
        if (movement.magnitude > 0)
        {
            Vector3 move = transform.TransformDirection(movement) * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + move);
        }
    }

    void AnimateMovement()
    {
        animator.SetFloat("speed", movement.magnitude);
    }
}
