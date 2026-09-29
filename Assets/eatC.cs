using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eatC : MonoBehaviour
{
    GameObject cat;

    void Start()
    {
        this.cat = GameObject.Find("cat");
    }

    void Update()
    {
        transform.Translate(0, -0.1f, 0);

        if (transform.position.y < -10.0f)
        {
            Destroy(gameObject);
        }

        Vector2 p1 = transform.position;
        Vector2 p2 = this.cat.transform.position;

        float d = Vector2.Distance(p1, p2);

        if (d < 0.6f)
        {
            GameObject dire = GameObject.Find("GameD");

            if (dire != null)
            {
                dire.GetComponent<GameD>().IncraseHp();
            }

            Destroy(gameObject);
        }
    }
}