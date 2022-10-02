using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, MoveInterface
{
    [Header ("Jump")]
    public string JumpButton;
    public float JumpForce;
    [Header("Check Grounded")]
    public Transform GroundCheckPoint;
    public LayerMask GroundLayer;
    public float radius;
    bool IsGrounded;
    [Header("Horizontal Movement")]
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckGrounded();
        Move();
    }

    public void CheckGrounded()
    {
        IsGrounded = Physics2D.OverlapCircle(GroundCheckPoint.position, radius, GroundLayer);
        if (IsGrounded)
        {
            Jump();
        }
    }
    public void Jump()
    {
        if (Input.GetKeyDown(JumpButton))
        {
            GetComponent<Rigidbody2D>().velocity = transform.up * JumpForce;
        }
    }

    public void Move()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, GetComponent<Rigidbody2D>().velocity.y);
    }
}
