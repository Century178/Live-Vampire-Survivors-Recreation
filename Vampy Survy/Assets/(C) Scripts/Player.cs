using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public float moveSpeed;
    private float x, y;

    public float health;
    private float hitCoolDown;

    private Rigidbody2D rb;
    private Animator am;
    private bool isMoving;

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        else Instance = this;

        rb = GetComponent<Rigidbody2D>();
        am = GetComponent<Animator>();
    }

    private void Update()
    {
        hitCoolDown -= Time.deltaTime;

        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        isMoving = (x == 0 && y == 0) ? false : true;
        am.SetBool("isMoving", isMoving);

        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * Mathf.Sign(x), transform.localScale.y, transform.localScale.z);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(x, y).normalized * moveSpeed;
    }

    private IEnumerator OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hitCoolDown <= 0)
        {
            health--;
            hitCoolDown = 1.5f;

            if (health <= 0)
            {
                am.SetBool("IsDead", true);
                GetComponent<Collider2D>().enabled = false;
                Time.timeScale = 0;
                yield return new WaitForSecondsRealtime(1);
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                am.SetBool("IsHurt", true);
                yield return new WaitForSeconds(0.25f);
                am.SetBool("IsHurt", false);
            }
        }
    }
}
