using System.Collections;
using UnityEngine;
using TMPro; // ใช้สำหรับ TextMeshPro

public class ShowMessageOnStart : MonoBehaviour
{
    public TextMeshProUGUI messageText; // อ้างอิงถึง TextMeshPro UI

    void Start()
    {
        messageText.gameObject.SetActive(true); // แสดงข้อความเมื่อเริ่มเกม
        StartCoroutine(HideTextAfterDelay(5f)); // ซ่อนข้อความหลัง 5 วินาที
    }

    IEnumerator HideTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        messageText.gameObject.SetActive(false); // ซ่อนข้อความ
    }
}
