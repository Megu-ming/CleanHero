using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    private Rigidbody2D rb;
    Vector2 moveDir = Vector2.zero;

    public Vector2 MoveDir
    {
        get { return moveDir; }
        set { moveDir = value.normalized; }
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");
        moveDir.Normalize();

        Vector3 dir = moveDir * moveSpeed * Time.deltaTime;
        transform.position += dir;

    }
}
