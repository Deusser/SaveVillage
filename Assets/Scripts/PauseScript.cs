using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    private bool paused;
    public AudioSource sound;
    public void PauseGame()
    {
        if (paused)
        {
            Time.timeScale = 1;
            sound.Play();
        }
        else
        {
            Time.timeScale = 0;
            sound.Pause();  
        }
        paused = !paused;
    }
}
