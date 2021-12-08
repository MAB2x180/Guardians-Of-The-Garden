using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelTimer : MonoBehaviour
{
    [SerializeField] float LevelTimeinSeconds = 10f;
    private Slider timeSlider;
    private bool triggeredLevelFinished = false; 
    // Start is called before the first frame update
    void Start()
    {
        timeSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggeredLevelFinished) { return; }
        timeSlider.value = Time.timeSinceLevelLoad / LevelTimeinSeconds;
        bool isTimerFinished = (Time.timeSinceLevelLoad >= LevelTimeinSeconds);

        if(isTimerFinished)
        {
            FindObjectOfType<GameManager>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }
    }
}
