using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    private Transform turrent_Transform;
    public float turrentRotationSpeed = 2.0f;
    private float moveTowardsRight;
    private float moveTowardsLeft;
    public float maximumPositiveRotation = 40.0f;
    public float maximumNegativeRotation = -40.0f;
    void Start()
    {
        turrent_Transform = this.transform;
    }
    private void TurrentControl() 
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            turrent_Transform.eulerAngles -= Vector3.forward * Time.deltaTime * turrentRotationSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            turrent_Transform.eulerAngles += Vector3.forward * Time.deltaTime * turrentRotationSpeed;
        }
        if (turrent_Transform.eulerAngles.z >= 60.0f && turrent_Transform.eulerAngles.z <= 100.0f) 
        {
            turrent_Transform.eulerAngles = Vector3.forward * 60.0f; //40
        }
        else if (turrent_Transform.eulerAngles.z <= 300.0f && turrent_Transform.eulerAngles.z >= 210.0f) 
        {
            turrent_Transform.eulerAngles = Vector3.forward * 300.0f;
        }
    }

    void Update()
    {
        if (GameManager.instance.gameStarted == false)
        {
            return;
        }
        TurrentControl();
    }
}
