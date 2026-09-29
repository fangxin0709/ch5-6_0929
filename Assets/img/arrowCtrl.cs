using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowCtrl : MonoBehaviour
{
    GameObject cat;

    void Start()
    {
        this.cat = GameObject.Find("cat");
    }

    void Update()
    {
        // 箭頭往下掉
        transform.Translate(0, -0.1f, 0);

        // 掉出畫面就刪除
        if (transform.position.y < -10.0f)
        {
            Destroy(gameObject);
        }

        // 計算箭頭和貓的距離
        Vector2 p1 = transform.position;
        Vector2 p2 = this.cat.transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;

        // 判斷是否碰到
        float r1 = 0.3f;
        float r2 = 0.3f;

        if (d < r1 + r2)
        {
            // 扣血
            GameObject dire = GameObject.Find("GameD");
            dire.GetComponent<GameD>().DecraseHp();

            // 箭頭消失
            Destroy(gameObject);
        }
    }
}