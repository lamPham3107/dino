using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMove : MonoBehaviour
{
    private float baseSpeed = 5f; // Speed of the land movement
    public static float speed;
    void Update()
    {
        speed = baseSpeed + GameController.GetScore() / 100f;
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

}
