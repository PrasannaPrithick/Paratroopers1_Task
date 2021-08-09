using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 20.0f;
    public Rigidbody2D rb_Bullet;

    private int willMakeDamage = 100;
    // Start is called before the first frame update
    void Start()
    {
        rb_Bullet.velocity = transform.up * bulletSpeed;
    }

    private void Update()
    {
        if(GameManager.instance.gameStarted == false) 
        {
            return;
        }
        if(transform.position.x > 15.0f || transform.position.x < -15.0f || transform.position.y > 15.0f) 
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D Info)
    {
        Enemy enemy = Info.GetComponent<Enemy>();
        SoldierDie soldierDie = Info.GetComponent<SoldierDie>();
        if(enemy != null) 
        {
            enemy.TakeDamage(willMakeDamage);
        }
        if (soldierDie != null)
        {
            soldierDie.TakeDamage(willMakeDamage);
        }
        Destroy(gameObject);
    }
}
