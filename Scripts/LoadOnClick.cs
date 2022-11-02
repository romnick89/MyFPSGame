using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Load on clicked script*/
public class LoadOnClick : MonoBehaviour
{
    //function run when In-game menu's main screen button is clicked
    public void LoadScene(int scene)
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //load scene number selected on inspector
#pragma warning disable CS0618 // Type or member is obsolete
        Application.LoadLevel(scene);
#pragma warning restore CS0618 // Type or member is obsolete
        ClickToLoadAsync.normalMode = 0;
        ClickToLoadAsyncHard.hardMode = 0;          
    }
}
