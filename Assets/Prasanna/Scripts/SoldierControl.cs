using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SoldierControl : MonoBehaviour
{
    public Animator soldier_Animator;
    public Rigidbody2D rb;
    private float canOpenParachuteAtYaxis;
    private bool characterOnGround;
    private BoxCollider2D characterBoxCollider;
    private bool soldiersLandedUpdateOnce = false;
    public Vector2 targetPoint_Left;
    public Vector2 targetPoint_Right;
    public BoxCollider2D[] climbSwitch_Collider;
    public int assignedSeat_Right;
    public int assignedSeat_Left;


    private bool seatAssignOnce = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (seatAssignOnce) 
        {
            return;
        }
        if(collision == climbSwitch_Collider[0]) 
        {
            //Physics2D.IgnoreLayerCollision(6, 8);
            rb.gravityScale = 0.0f;
            GameManager.instance.climbToSeatPosition_Right += 1;
            if(GameManager.instance.climbToSeatPosition_Right >= 5) 
            {
                GameManager.instance.gameOver = true;
                UIManager.instance.GameOverPopup();
                Time.timeScale = 0.0f;

                return;
            }
            assignedSeat_Right = GameManager.instance.climbToSeatPosition_Right-1;
            transform.SetParent(GameManager.instance.seatToCreateSteps_Right[assignedSeat_Right].transform);
            StartCoroutine(ResetPlayerPosition());
            seatAssignOnce = true;
        }
        else if(collision == climbSwitch_Collider[1]) 
        {
            //Physics2D.IgnoreLayerCollision(6, 8);
            rb.gravityScale = 0.0f;
            GameManager.instance.climbToSeatPosition_Left += 1;
            if (GameManager.instance.climbToSeatPosition_Left >= 5)
            {
                GameManager.instance.gameOver = true;
                UIManager.instance.GameOverPopup();
                Time.timeScale = 0.0f;
                return;
            }
            assignedSeat_Left = GameManager.instance.climbToSeatPosition_Left - 1;
            transform.SetParent(GameManager.instance.seatToCreateSteps_Left[assignedSeat_Left].transform);
            StartCoroutine(ResetPlayerPosition());
            seatAssignOnce = true;
        }
    }

    private IEnumerator ResetPlayerPosition() 
    {
        yield return new WaitForSeconds(0.5f);
        transform.localPosition = new Vector2(0.0f, 0.0f);
    }


    void Start()
    {
        Physics2D.IgnoreLayerCollision(6, 6);
        //CharacterEjectFromCopter();
        canOpenParachuteAtYaxis = Random.Range(0.0f, 1.0f);

        characterBoxCollider = this.GetComponent<BoxCollider2D>();

        RotateCharacter();
        climbSwitch_Collider[0] = GameObject.Find("RocketLauncher/CimbSwitch_Right").GetComponent<BoxCollider2D>();
        climbSwitch_Collider[1] = GameObject.Find("RocketLauncher/CimbSwitch_Left").GetComponent<BoxCollider2D>();
    }

    private void RotateCharacter() 
    {
        if ((int)(transform.position.x) >= 0.0f)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
      }

    private void CharacterEjectFromCopter() 
    {
        if (transform.position.y <= canOpenParachuteAtYaxis)
        {
            if (rb.drag != 2.0f)
            {
                rb.drag = 2.0f;
            }
        }
    }

    private void CanOpenParachute() 
    {
        if (transform.position.y <= canOpenParachuteAtYaxis)
        {
            if (soldier_Animator.GetBool("OpeningParachute") == false) 
            {
                soldier_Animator.SetBool("OpeningParachute", true);
                SFXManager.instance.SoldierOpenedParachute();
            }
            if(rb.drag != 9.0f) 
            {
                if ((int)(transform.position.x) >= 0.0f)
                {
                    transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f);
                }
                else 
                {
                    transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                }
                    
                rb.drag = 5.0f;
            }
        }
    }

    private void SoldierIsOnGround() 
    {
        
        if(transform.position.y <= -4.0f) 
        {
            if (soldier_Animator.GetBool("Landed") == false)
            {
                soldier_Animator.SetBool("Landed", true);
            }
            if (soldier_Animator.GetBool("SooldierParachuteDestroyed") == false)
            {
                soldier_Animator.SetBool("SooldierParachuteDestroyed", true);
            }
            if (soldier_Animator.GetBool("CharacterCanRunNow") == false)
            {
                soldier_Animator.SetBool("CharacterCanRunNow", true);
            }

            if(targetAssignedOnce == true)
            {
                StartCoroutine(TargetAssignedDelay());
                targetAssignedOnce = false;
            }
            
            
            SoldiersLandedCount();
        }
    }

    private float soldierMovementSpeed = 1.0f;
    public bool targetAssined = false;
    private bool targetAssignedOnce = true;
    private IEnumerator TargetAssignedDelay() 
    {
        yield return new WaitForSeconds(1.8f);
        SFXManager.instance.SoldierLanded();
        targetAssined = true;
    }
    private void RunTowardsTurrent() 
    {
        if (targetAssined == true) 
        {
            if (transform.position.x <= 0.0f)
            {
                float step = soldierMovementSpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, targetPoint_Left, step);
            }
            else if (transform.position.x > 0.0f)
            {
                float step = soldierMovementSpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, targetPoint_Right, step);
            }
        }
        if(transform.position.x == targetPoint_Left.x || transform.position.x == targetPoint_Right.x) 
        {
            if (soldier_Animator.GetBool("SoldierReachedTarget") == false)
            {
                soldier_Animator.SetBool("SoldierReachedTarget", true);
            }
            
            targetAssined = false;
        }
            
    }

    private void SoldiersLandedCount() 
    {
        if(transform.position.x <= 0.0f && soldiersLandedUpdateOnce == false) 
        {
            GameManager.instance.leftSideEnemiesLandedCount += 1;
            soldiersLandedUpdateOnce = true;
        }
        else if(transform.position.x > 0.0f && soldiersLandedUpdateOnce == false)
        {
            GameManager.instance.rightSideEnemiesLandedCount += 1;
            soldiersLandedUpdateOnce = true;
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameStarted == false)
        {
            return;
        }
        CharacterEjectFromCopter();
        CanOpenParachute();
        SoldierIsOnGround();

        RunTowardsTurrent();
    }
}
