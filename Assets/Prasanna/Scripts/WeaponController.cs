using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject rocketLauncherBullet_Prefab;
    public GameObject turret_GO;
    public GameObject turretHolder_GO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Shoot() 
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(rocketLauncherBullet_Prefab, firePoint.position, firePoint.rotation);
            SFXManager.instance.FireSoundPlayOnce();
        }
    }
    

    private void Die()
    {
        Destroy(turret_GO);
        Destroy(turretHolder_GO);
        //Time.timeScale = 0.0f;
    }

    void Update()
    {
        if (GameManager.instance.gameStarted == false)
        {
            return;
        }
        Shoot();
        if (GameManager.instance.gameOver) 
        {
            Die();
        }
    }
}
