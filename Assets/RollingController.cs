using UnityEngine;

public class RollingController : MonoBehaviour
{
    public float speed = 10f;
    public float acceleration = 2f;
    private float currentSpeed;
    private Rigidbody rb;
    
    public GameOverManager gameOverManager;

    public float gravityMultiplier = 2f; // เพิ่มความแรงของแรงโน้มถ่วง
    public float airDrag = 2f; // แรงเสียดทานในอากาศ

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = speed;

        // ปรับแรงเสียดทานในอากาศ
        rb.linearDamping = airDrag;

        // ปรับแรงโน้มถ่วงให้มากขึ้น
        Physics.gravity = new Vector3(0, -20f, 0); // ทำให้ตกเร็วขึ้น
    }

    void Update()
    {
        float moveHorizontal = 0f;
        float moveVertical = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveHorizontal = -1f;
            currentSpeed += acceleration * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveHorizontal = 1f;
            currentSpeed = speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveVertical = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveVertical = 1f;
        }

        Vector3 move = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(move * currentSpeed);

        // เพิ่มแรงโน้มถ่วงพิเศษ
        rb.AddForce(Vector3.down * gravityMultiplier, ForceMode.Acceleration);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameOverManager.ShowGameOver();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            gameOverManager.ShowGameOver();
        }
    }
}
