using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{

    [SerializeField] int playerLives = 10, damage = 1;
    private Text livesText;
    // Start is called before the first frame update
    void Start()
    {
        livesText = GetComponent<Text>();
        UpdateLives();
    }
    private void UpdateLives()
    {
        livesText.text = playerLives.ToString();
    }

    public void TakeLife()
    {
        playerLives -= damage;
        UpdateLives();

        if(playerLives <= 0)
        {
            FindObjectOfType<GameManager>().HandleLoseCondition();
            //FindObjectOfType<LevelLoader>().LoadGameOver();
        }
    }
}
