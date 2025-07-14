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


}
