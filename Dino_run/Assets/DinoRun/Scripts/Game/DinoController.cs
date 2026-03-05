using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DinoController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float jumpForce = 17f;
    private bool isStarted = true;
    private bool isEating = false;

    public static Animator animator;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (IsPointerOverUI())
            return;
        animator.SetBool("isGrounded", CheckGrounded.Instance.isGrounded);
        // Check for jump input
        Debug.Log("Is Grounded: " + CheckGrounded.Instance.isGrounded);
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && CheckGrounded.Instance.isGrounded)
        {
            if (isStarted)
            {
                isStarted = false;
            }
            else
            {
                jump();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameController.instance.EndGame();
        }


    }
    private void jump()
    {
        if (CheckGrounded.Instance.isGrounded)
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    private bool IsPointerOverUI()
    {
        if (Application.isMobilePlatform)
        {
            if (Input.touchCount > 0)
            {
                return EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);
            }
        }
        else
        {
            return EventSystem.current.IsPointerOverGameObject();
        }
        return false;
    }


    

}
