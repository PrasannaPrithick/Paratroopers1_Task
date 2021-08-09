using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Start()
    {
        
    }

    public int leftSideEnemiesLandedCount;
    public int rightSideEnemiesLandedCount;
    public int climbToSeatPosition_Left;
    public int climbToSeatPosition_Right;
    public GameObject[] seatToCreateSteps_Right;
    public GameObject[] seatToCreateSteps_Left;
    public bool gameOver = false;
    public bool gameStarted = false;
    public float gameLevel = 3;
    public int gameScore;

    public int helicopterScore = 100;
    public int atomBombScore = 100;
    public int soldierScore = 50;

    private void Awake()
    {
        if(instance != null) 
        {
            return;
        }
        instance = this;
    }

}
