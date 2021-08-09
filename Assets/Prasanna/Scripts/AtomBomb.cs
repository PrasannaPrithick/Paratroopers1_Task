using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomBomb : MonoBehaviour
{
    public Transform turretPosition;
    void Start()
    {
        turretPosition = GameObject.Find("RocketLauncher/AtomBombReferencePointToaffect").GetComponent<Transform>();
    }

    private float bombTravelSpeed = 5.0f;
    private void DroppedTowardsTurrent()
    {
        float travelspeed = bombTravelSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, turretPosition.position, travelspeed);
        if(transform.position == turretPosition.position) 
        {
            GameManager.instance.gameOver = true;
            UIManager.instance.GameOverPopup();
            Time.timeScale = 0.0f;
            Destroy(gameObject);
        }
    }

        // Update is called once per frame
     void Update()
    {
        if (GameManager.instance.gameStarted == false)
        {
            return;
        }
        DroppedTowardsTurrent();
    }
}
