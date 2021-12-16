using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource musicPlayer;
    // Start is called before the first frame update

    private void Awake()
    {
        int numOfPlayers = FindObjectsOfType<MusicPlayer>().Length;
        
        if(numOfPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
        }
    }
    void Start()
    {
        
        musicPlayer = GetComponent<AudioSource>();
        musicPlayer.volume = PlayerPrefsController.GetMasterVolume();
    }

    public void SetVolume(float volume)
    {
        musicPlayer.volume = volume;
    }
}
