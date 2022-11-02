using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*Click to load async normal mode script*/
public class ClickToLoadAsync : MonoBehaviour
{
    public static int normalMode = 0;
    public Slider loadingBar;
    public GameObject loadingImage;
    public AudioClip gunSound;

    private AsyncOperation async;
    //load scene selected from start menu
    public void ClickAsync(int scene)
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(gunSound);
        normalMode = scene;
        if (PlayerCollision.isGameOver)
        {
            PlayerCollision.isGameOver = false;
        }
        //lock and hide cursor 
        //unpause game
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        loadingImage.SetActive(true);
        StartCoroutine(LoadSceneWithBar(scene));
    }
    //set loading screen
    IEnumerator LoadSceneWithBar(int scene)
    {        
#pragma warning disable CS0618 // Type or member is obsolete
        async = Application.LoadLevelAsync(scene);
#pragma warning restore CS0618 // Type or member is obsolete
        while (!async.isDone)
        {
            loadingBar.value = async.progress;
            yield return null;
        }
    }

}
