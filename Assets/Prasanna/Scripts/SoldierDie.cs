using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierDie : MonoBehaviour
{
    public int enemyHealth = 100;


    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        UIManager.instance.ScoreUpdate(GameManager.instance.soldierScore);
        Destroy(gameObject);
        SFXManager.instance.SoldierKilled();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        Physics2D.IgnoreLayerCollision(6, 6);
    }

}
