using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGrounded : MonoBehaviour
{
    public bool isGrounded;
    public static CheckGrounded Instance { get; private set; }
    [SerializeField] public float range = 2f;
    public LayerMask groundLayer; 

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Update()
    {
        Vector2 rayOrigin = new Vector2(transform.position.x, transform.position.y - range);
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, 0.5f);

        // Check tag thay vì layer
        isGrounded = hit.collider != null && hit.collider.CompareTag("Ground");
        Debug.DrawRay(transform.position, Vector2.down * 1f,
        isGrounded ? Color.green : Color.red);
       
    }

}
