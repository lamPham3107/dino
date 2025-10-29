using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGrounded : MonoBehaviour
{
    public bool isGrounded;
    public static CheckGrounded Instance { get; private set; }

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        isGrounded = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && !collision.gameObject.CompareTag("Character") && !collision.gameObject.CompareTag("Enemy") && !collision.gameObject.CompareTag("Bug"))
        {
            isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null && !collision.gameObject.CompareTag("Character") && !collision.gameObject.CompareTag("Bug"))
        {
            isGrounded = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null && !collision.gameObject.CompareTag("Character") && !collision.gameObject.CompareTag("Enemy") && !collision.gameObject.CompareTag("Bug"))
        {
            isGrounded = true;
        }
    }

    private void setRun()
    {
       DinoController.animator.SetTrigger("run");
    }
}
