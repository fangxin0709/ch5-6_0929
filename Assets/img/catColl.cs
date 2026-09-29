using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class catColl : MonoBehaviour
{
    Rigidbody2D rigid2D;

    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;

    Animator animator;

    // 計時
    float gameTime = 0f;
    bool gameClear = false;

    void Start()
    {
        Application.targetFrameRate = 60;

        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();

        // 重新開始遊戲，破關時間歸零
        PlayerPrefs.SetFloat("ClearTime", 0f);
        PlayerPrefs.Save();
    }

    void Update()
    {
        // 遊戲進行中才計時
        if (!gameClear)
        {
            gameTime += Time.deltaTime;
        }

        // 跳躍
        if (Input.GetKeyDown(KeyCode.Space) &&
            this.rigid2D.velocity.y == 0)
        {
            this.animator.SetTrigger("jumpt");
            this.rigid2D.AddForce(
                transform.up * this.jumpForce
            );
        }

        // 左右移動
        int key = 0;

        if (Input.GetKey(KeyCode.RightArrow))
            key = 1;

        if (Input.GetKey(KeyCode.LeftArrow))
            key = -1;

        float speedX = Mathf.Abs(
            this.rigid2D.velocity.x
        );

        if (speedX < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(
                transform.right * key * this.walkForce
            );
        }

        // 面向方向
        if (key != 0)
        {
            transform.localScale =
                new Vector3(key, 1, 1);
        }

        // 動畫速度
        if (this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedX / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }

        // 掉出地圖
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("cleraS");
        }
    }

    // 碰到終點
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("終點");

        if (!gameClear)
        {
            gameClear = true;

            // 儲存破關時間
            PlayerPrefs.SetFloat(
                "ClearTime",
                gameTime
            );

            PlayerPrefs.Save();

            // 前往破關畫面
            SceneManager.LoadScene("gameSence");
        }
    }
}
