using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;  // ลาก Game Over UI มาที่นี่ใน Inspector

    void Start()
    {
        // ซ่อน UI Game Over ตอนเริ่มเกม
        gameOverUI.SetActive(false);
    }

    public void ShowGameOver()
    {
        gameOverUI.SetActive(true);  // แสดง UI Game Over เมื่อเกิด Game Over
        Time.timeScale = 0f; // หยุดเกม
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // กลับมาเล่นเกมได้
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToPreviousScene()
    {
        Time.timeScale = 1f; // กลับมาเล่นเกมได้
        int previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        if (previousSceneIndex >= 0)
        {
            SceneManager.LoadScene(previousSceneIndex);
        }
        else
        {
            Debug.Log("ไม่มีซีนก่อนหน้า!");
        }
    }
}
