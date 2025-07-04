using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform cameraTransform;
    private float mouseSensivity = 100f;
    private Animator animator;


    private float xRotate = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("There is no animator");
        }
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        MoveHandler();
        RotationHandler();
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

    void MoveHandler()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(h, 0, v);

        transform.Translate(direction * this.speed * Time.deltaTime);

        animator.SetFloat("speed", (direction * this.speed).magnitude);
    }
}
