using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eatG : MonoBehaviour // 建議類別名稱拼寫可順便修正為 Gen (Generator)
{
    public GameObject arrowPrefab;
    float span = 0.5f; // 生成間隔時間（秒）
    float delta = 0;   // 累積時間

    void Start()
    {

    }

    void Update()
    {
        // 1. 累加每幀經過的時間
        this.delta += Time.deltaTime;

        // 2. 當累積時間超過預設的間隔時間 (1秒) 時才執行
        if (this.delta > this.span)
        {
            this.delta = 0; // 重置計時器

            // 生成箭矢並設定位置
            GameObject go = Instantiate(arrowPrefab);
            int px = Random.Range(-8, 8); // 隨機產生 -6 到 6 的整數 X 軸位置
            go.transform.position = new Vector3(px, 7, 0);
        }
    }
}