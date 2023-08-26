using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float health;

    private Transform target;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        target = Player.player.transform;
        GameManager.Instance.enemyList.Add(transform);
    }

    private void FixedUpdate()
    {
        rb.position = Vector2.MoveTowards(rb.position, (Vector2)target.position, moveSpeed * Time.fixedDeltaTime);

        if ((rb.position.x - target.position.x) > 0) sr.flipX = true;
        else sr.flipX = false;
    }

    public void TakeDamage(float amt)
    {
        health -= amt;
        if (health <= 0) Die();
    }
    private void Die()
    {
        GameManager.Instance.enemyList.Remove(transform);
        GameManager.Instance.AddExperience(40);
        Destroy(gameObject);
    }
}
