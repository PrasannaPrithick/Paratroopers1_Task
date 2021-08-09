using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth = 100;
    

    public void TakeDamage(int damage) 
    {
        enemyHealth -= damage;
        if(enemyHealth <= 0) 
        {
            Die();
        }
    }
    private void AutoDestroyWhenCopterCrossTheRange() 
    {
        if(transform.position.x > 13.0f || transform.position.x < -13.0f) 
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (GameManager.instance.gameStarted == false)
        {
            return;
        }
        AutoDestroyWhenCopterCrossTheRange();
    }

    private void Die() 
    {
        UIManager.instance.ScoreUpdate(GameManager.instance.helicopterScore);
        Destroy(gameObject);
        SFXManager.instance.PlayerGotDestroyed();
    }
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(6, 6);
    }

}
