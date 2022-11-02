using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Quit Game Scrip*/
public class Quit : MonoBehaviour
{
    public void QuitGame()
    {
        //quit application
        Application.Quit();

        //for testing only
        //quit editor
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
