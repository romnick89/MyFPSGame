using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
/*In-game Main menu Script*/
public class MainMenu : MonoBehaviour
{
    //variable to trigger if game is paused
    public static bool isPause = false;
    //menu variables
    public GameObject pauseMenu;
    public GameObject player;
    public Text missionDisplay;
    public Text controlsDisplay;
    public GameObject volumeDisplay; 

    // Update is called once per frame
    void Update()
    {
        if (!PlayerCollision.isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPause)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }
    }
    //resume game
    public void ResumeGame()
    {
        player.GetComponent<FirstPersonController>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //toggle menu
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
    }
    //pause game
    public void PauseGame()
    {
        player.GetComponent<FirstPersonController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //toggle menu
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;      
    }
    //display mission GUI
    public void DisplayMission()
    {
        if (!missionDisplay.enabled)
        {
            missionDisplay.enabled = true;
        }
        if (controlsDisplay.enabled)
        {
            controlsDisplay.enabled = false;
        }

#pragma warning disable CS0618 // Type or member is obsolete
        if (volumeDisplay.active)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            volumeDisplay.SetActive(false);
        }
    }
    //display controls GUI
    public void DisplayContols()
    {
        if (!controlsDisplay.enabled)
        {
            controlsDisplay.enabled = true;
        }
        if (missionDisplay.enabled)
        {
            missionDisplay.enabled = false;
        }

#pragma warning disable CS0618 // Type or member is obsolete
        if (volumeDisplay.active)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            volumeDisplay.SetActive(false);
        }
    }
    //display volume GUI
    public void DisplayVolume()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        if (!volumeDisplay.active)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            volumeDisplay.SetActive(true);
        }

        if (missionDisplay.enabled)
        {
            missionDisplay.enabled = false;
        }

        if (controlsDisplay.enabled)
        {
            controlsDisplay.enabled = false;
        }
    }
}
