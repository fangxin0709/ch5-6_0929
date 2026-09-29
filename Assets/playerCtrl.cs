using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }
    public void LB_down()
    {
        transform.Translate(-2, 0, 0);
        ClampPosition();
    }
    public void RB_down()
    {
        transform.Translate(2, 0, 0);
        ClampPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Translate(-0.2f, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0.2f, 0, 0);
        }
        ClampPosition();
    }

    void ClampPosition()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -8.0f, 8.0f);
        transform.position = pos;
    }
}
