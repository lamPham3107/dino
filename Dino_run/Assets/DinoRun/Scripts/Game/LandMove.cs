using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMove : MonoBehaviour
{
    private float speed = 7f; // Speed of the land movement

   
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
