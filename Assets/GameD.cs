using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameD : MonoBehaviour
{
    GameObject hpG;

    public TextMeshProUGUI hpText;       // HP文字
    public TextMeshProUGUI timerText;    // 計時器文字

    float timer = 30.0f;

    void Start()
    {
        this.hpG = GameObject.Find("hpG");

        UpdateHpText();
    }

    public void DecraseHp()
    {
        this.hpG.GetComponent<Image>().fillAmount -= 0.1f;

        UpdateHpText();

        if (this.hpG.GetComponent<Image>().fillAmount <= 0)
        {
            RestartGame();
        }
    }

    public void IncraseHp()
    {
        this.hpG.GetComponent<Image>().fillAmount += 0.1f;

        UpdateHpText();
    }

    // 更新HP文字
    void UpdateHpText()
    {
        float hp = this.hpG.GetComponent<Image>().fillAmount * 100;

        hpText.text = "HP:" + hp.ToString("0");
    }

    void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer < 0)
            {
                timer = 0;
            }

            if (timerText != null)
            {
                timerText.text = "Time Left:" +
                    Mathf.CeilToInt(timer).ToString() + "s";
            }
        }
        else
        {
            EndGame();
        }
    }

    void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}