using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float attackSpeed;
    public float attackPower;
    public float attackRange;
    public float health;

    private float x, y;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        if (x < 0) sr.flipX = true;
        else if (x > 0) sr.flipX = false;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(x, y).normalized * moveSpeed;
    }
}
