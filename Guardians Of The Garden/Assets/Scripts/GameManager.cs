using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int NumOfAttackers = 0;
    private bool isTimerFinshed = false;
    
    public void AttackerSpawned()
    {
        NumOfAttackers++;
    }

    public void AttackerKilled()
    {
        NumOfAttackers--;

        if(NumOfAttackers <= 0 && isTimerFinshed == true)
        {
            Debug.Log("End Level Now");
        }
    }

    public void LevelTimerFinished()
    {
        isTimerFinshed = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();

        foreach(AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
