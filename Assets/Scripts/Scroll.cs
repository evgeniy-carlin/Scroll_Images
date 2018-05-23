using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    private float speed = 7.5f;

    private void Update()
    {
        //Makes object move in vertical direction (Up and Down arrows)
        float v = Input.GetAxis("Vertical") * speed;
        v *= Time.deltaTime;
        transform.position += new Vector3(0, v, 0);
    }
}
