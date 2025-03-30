using UnityEngine;
using TMPro; // ใช้ TextMeshPro namespace
using System.Collections;

public class GameStartTMP : MonoBehaviour
{
    public TextMeshProUGUI messageText; // เปลี่ยนเป็น TextMeshProUGUI

    void Start()
    {
        // ซ่อนข้อความในตอนเริ่มต้น
        messageText.gameObject.SetActive(false);

        // เริ่มต้นการนับเวลา 5 วินาที
        StartCoroutine(ShowMessageAfterDelay());
    }

    IEnumerator ShowMessageAfterDelay()
    {
        // รอ 5 วินาที
        yield return new WaitForSeconds(5);

        // แสดงข้อความ
        messageText.gameObject.SetActive(true);
    }
}
