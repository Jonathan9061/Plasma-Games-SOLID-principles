using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour, MoveInterface
{
    [Header("Jump")]
    public float JumpForce;
    public float timebetweenjumpcheck;
    float nextjump;
    public int jumpprob;
    [Header("Check Grounded")]
    public Transform GroundCheckPoint;
    public LayerMask GroundLayer;
    public float radius;
    bool IsGrounded;
    [Header("Horizontal Movement")]
    public float speed;
    Transform Player;
    public int moveprob;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(Random.Range(-8, 8), 10);
        speed += Random.Range(-2f, 3f);
        Player = GameObject.FindGameObjectWithTag("Player").transform;
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
        if(nextjump < Time.time)
        {
            if (Random.Range(0, jumpprob) == 1)
            {
                GetComponent<Rigidbody2D>().velocity = transform.up * JumpForce;
            }
            nextjump = timebetweenjumpcheck + Time.time;
        }


        
    }

    public void Move()
    {
            if (Random.Range(0, moveprob) == 1)
            {
                if (Player.position.x + 1 < transform.position.x)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
                }
                else if (Player.position.x - 1 > transform.position.x)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
                }
            }
        


    }
}
