using UnityEngine;
using UnityEngine.SceneManagement; // เพิ่ม namespace นี้

public class Revers : MonoBehaviour
{
    public void GoToPreviousScene()
    {
        Time.timeScale = 1f; // กลับมาเล่นเกมได้
        int previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        if (previousSceneIndex >= 0)
        {
            SceneManager.LoadScene(previousSceneIndex);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // กลับมาเล่นเกมได้
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
