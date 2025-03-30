using UnityEngine;

public class CheckpointUI : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main; // หา Main Camera อัตโนมัติ
    }

    void Update()
    {
        if (mainCamera != null)
        {
            transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward);
        }
    }
}
