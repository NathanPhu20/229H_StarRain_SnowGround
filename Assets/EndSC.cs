using UnityEngine;
using UnityEngine.SceneManagement; // ใช้สำหรับเปลี่ยน Scene

public class ChangeSceneOnCollision : MonoBehaviour
{
    public string nextSceneName = "NextScene"; // ชื่อซีนที่ต้องการเปลี่ยนไป

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(nextSceneName); // เปลี่ยนซีนทันทีที่ชน
    }
}
