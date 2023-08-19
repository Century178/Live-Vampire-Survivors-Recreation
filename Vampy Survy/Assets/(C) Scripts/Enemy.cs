using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float health;

    private Transform target;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        target = Player.player.transform;
    }

    private void FixedUpdate()
    {
        rb.position = Vector2.MoveTowards(rb.position, (Vector2)target.position, moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health--;

            if (health <= 0) Destroy(gameObject);
        }
    }
}
