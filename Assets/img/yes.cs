using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class yes : MonoBehaviour
{
    public TMP_Text text;

    void Start()
    {
        // 讀取破關時間
        float clearTime = PlayerPrefs.GetFloat("ClearTime", 0f);

        // 顯示時間
        text.text =
            "Use time:" + clearTime.ToString("F2") + "s";
    }

    void Update()
    {
        // 滑鼠點一下回到遊戲
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("ch6_GameScreen");
        }
    }
}
