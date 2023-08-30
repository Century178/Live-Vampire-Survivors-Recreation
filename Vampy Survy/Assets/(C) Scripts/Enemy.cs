using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float health;

    private Transform target;

    private void Start()
    {
        target = Player.Instance.transform;
        GameManager.Instance.enemyList.Add(transform);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -Mathf.Sign(transform.position.x - target.position.x), transform.localScale.y, transform.localScale.z);
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
