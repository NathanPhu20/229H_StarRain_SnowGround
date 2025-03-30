using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // ตำแหน่งที่กล้องจะมองไป (เช่น Skateboard)
    public Camera camera;    // กล้องที่ใช้ในการแสดงผล
    public float sensitivity = 3f;  // ความไวของการหมุน
    public float minY = -40f;  // มุมหมุนกล้องขั้นต่ำ (แกน X)
    public float maxY = 40f;   // มุมหมุนกล้องสูงสุด (แกน X)
    private float rotationX = 0f; // มุมหมุนของกล้องในแกน X
    private bool isRightMousePressed = false;  // เช็คว่ากดเมาส์ขวาค้างอยู่หรือไม่

    void Start()
    {
        if (camera == null)
        {
            camera = Camera.main;  // ใช้กล้องหลักหากไม่ได้กำหนด
        }
    }

    void Update()
    {
        if (target == null || camera == null)
        {
            Debug.LogError("Target or Camera is not set!");
            return;  // หยุดการทำงานหากไม่ได้ตั้งค่า
        }

        // เช็คการกดเมาส์ขวา
        if (Input.GetMouseButtonDown(1)) // 1 คือเมาส์ขวา
        {
            isRightMousePressed = true;
        }
        else if (Input.GetMouseButtonUp(1)) // เมื่อปล่อยเมาส์ขวา
        {
            isRightMousePressed = false;
        }

        if (isRightMousePressed)
        {
            // หมุนกล้องตามการเคลื่อนที่ของเมาส์
            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

            // หมุนกล้องในแนวนอน (แกน Y)
            transform.Rotate(0, mouseX, 0);

            // คำนวณมุมหมุนในแนวตั้ง (แกน X)
            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, minY, maxY);  // จำกัดมุมหมุนในแนวตั้ง

            // หมุนกล้องในแนวตั้ง (แกน X)
            camera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        }
    }
}
