using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public float damage;
    public Vector2 direction;
    public void Reset(Vector2 direction, float damageMulti)
    {
        this.direction = direction.normalized;
        damage *= damageMulti;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)direction * Time.deltaTime* bulletSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
