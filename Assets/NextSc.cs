using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // ตรวจสอบว่ามีซีนถัดไปหรือไม่
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("ไม่มีซีนถัดไป!");
        }
    }
}
