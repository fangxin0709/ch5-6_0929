using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarColl : MonoBehaviour
{
    GameObject cat;
    // Start is called before the first frame update
    void Start()
    {
        this.cat = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = this.cat.transform.position;
        transform.position = new Vector3(
        transform.position.x, playerPos.y, transform.position.z);
    }
}
