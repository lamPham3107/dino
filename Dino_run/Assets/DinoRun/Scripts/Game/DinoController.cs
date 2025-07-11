using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DinoController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float jumpForce = 20f;


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
        // Check for jump input
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            jump();
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
#if UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            return EventSystem.current.IsPointerOverGameObject(touch.fingerId);
        }
        return false;
#else
    return EventSystem.current.IsPointerOverGameObject();
#endif
    }


}
