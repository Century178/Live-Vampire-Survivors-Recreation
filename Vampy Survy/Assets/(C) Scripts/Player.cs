using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    private float x, y;

    public float attackSpeed;
    public float attackPower;
    public float attackRange;
    public float health;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator am;
    private bool isMoving;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        am = GetComponent<Animator>();
    }

    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(x) > 0.1f || Mathf.Abs(y) > 0.1f) isMoving = true;
        else isMoving = false;
        am.SetBool("isMoving", isMoving);

        if (x < 0) sr.flipX = true;
        else if (x > 0) sr.flipX = false;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(x, y).normalized * moveSpeed;
    }
}
