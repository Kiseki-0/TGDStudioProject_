using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKiller : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var enemy = collision.gameObject.GetComponent<EnemyAI>();
            var player = gameObject.GetComponent<PlayerLife>();
            //Destroy(this.gameObject);
            player.Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            rb.AddForce(new Vector2(0, 1500));
            var enemy = collision.gameObject.GetComponent<EnemyAI>();
            enemy.Die();
        }
    }

}
