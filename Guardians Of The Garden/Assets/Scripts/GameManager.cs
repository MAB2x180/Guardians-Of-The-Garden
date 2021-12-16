using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float waitToLoad = 4.0f;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLable;
    private int NumOfAttackers = 0;
    private bool isTimerFinshed = false;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLable.SetActive(false);
    }
    public void AttackerSpawned()
    {
        NumOfAttackers++;
    }

    public void AttackerKilled()
    {
        NumOfAttackers--;

        if(NumOfAttackers <= 0 && isTimerFinshed == true)
        {
            StartCoroutine(HandleWinCondition());
        }
    }
    IEnumerator HandleWinCondition()
    {
        
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        Time.timeScale = 0;
        loseLable.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("lose");
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
