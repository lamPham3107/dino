using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugController : MonoBehaviour
{
    private float bugSpeed = 10f;

    private void Update()
    {
        Fly();
    }

    private void Fly()
    {
        transform.Translate(Vector3.left * bugSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Character"))
        {
            bugSpeed = 0f;
        }

    }

}
