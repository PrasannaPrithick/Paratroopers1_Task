using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterController : MonoBehaviour
{
    public float helicopterSpeed;
    public Rigidbody2D rb_Choppers;
    public Transform dropableReferencePoint;
    public GameObject dropableObject_GO;
    private bool dropOnce = false;
    private bool isSafeZoneToDrop = false;
    private int randomDropLeftorRight;
    private int randomLeftPosition;
    private int randomRightPosition;
    public GameObject droppingBomb_GO;
    // Start is called before the first frame update
    void Start()
    {
        helicopterSpeed = Random.Range(6, 10);
        rb_Choppers.velocity = transform.right * helicopterSpeed;

        randomDropLeftorRight = Random.Range(1, 100);
        randomLeftPosition = Random.Range(-1, -7);
        randomRightPosition = Random.Range(1, 7);
    }

    private void Update()
    {
        if (GameManager.instance.gameStarted == false)
        {
            return;
        }
        CopterCanDropNow();
    }

    private void CopterCanDropNow() 
    {
        if((transform.position.x <= 7.3f && transform.position.x >= 1.5) 
            || (transform.position.x >= -7.3f && transform.position.x <= -1.5f))
        {
            if(isSafeZoneToDrop == false) 
            {
                isSafeZoneToDrop = true;
            }
        }
        else 
        {
            if (isSafeZoneToDrop == true)
            {
                isSafeZoneToDrop = false;
            }
        }

        if (isSafeZoneToDrop) 
        {
            CanDropNow();
        }
    }

    private void CanDropNow() 
    {
        if (randomDropLeftorRight <= 30)
        {
            if (((int)(transform.position.x) == randomLeftPosition && dropOnce == false))
            {
                Instantiate(dropableObject_GO, dropableReferencePoint.position, Quaternion.identity);
                dropOnce = true;
            }
        }
        else if (randomDropLeftorRight <= 60)
        {
            if ((int)(transform.position.x) == randomRightPosition && dropOnce == false)
            {
                Instantiate(dropableObject_GO, dropableReferencePoint.position, Quaternion.identity);
                dropOnce = true;
            }
        }
        else if (randomDropLeftorRight <= 90)
        {
            //Do nothing... only helicopter can fly... No drops from copter...
        }
        else if(randomDropLeftorRight >= 91 && dropOnce == false)
        {
            
            Instantiate(droppingBomb_GO, dropableReferencePoint.position, dropableReferencePoint.rotation);
            dropOnce = true;
        }
    }

}
