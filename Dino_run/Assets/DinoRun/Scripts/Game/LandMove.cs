using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMove : MonoBehaviour
{
    private float baseSpeed = 9f; // Speed of the land movement
    public static float speed;
    void Update()
    {
        speed = baseSpeed + GameController.GetDistance() / 200f;
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

}
