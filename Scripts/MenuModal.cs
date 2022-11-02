using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*Start menu modal Script*/
public class MenuModal : MonoBehaviour
{
    public GameObject modalMenu;
    public GameObject volumeControl;
    public Text storyText;
    public Text controlsText;

    private void Start()
    {
        //activate cursor mode
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    //load modal for menu
    public void ClickToLoadModal()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        if (!modalMenu.active)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            modalMenu.SetActive(true);
        }
    }
    //close modal menu
    public void ClickToCloseModal()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        if (modalMenu.active)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            modalMenu.SetActive(false);
        }
    }
    //load to view Story Text GUI
    public void ClickToviewStory()
    {
        if (!storyText.enabled)
        {
            storyText.enabled = true;
        }

        if (controlsText.enabled)
        {
            controlsText.enabled = false;
        }

#pragma warning disable CS0618 // Type or member is obsolete
        if (volumeControl.active)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            volumeControl.SetActive(false);
        }
    }
    //load to view Controls text GUI
    public void ClickToViewControls()
    {
        if (!controlsText.enabled)
        {
            controlsText.enabled = true;
        }

        if (storyText.enabled)
        {
            storyText.enabled = false;
        }
#pragma warning disable CS0618 // Type or member is obsolete
        if (volumeControl.active)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            volumeControl.SetActive(false);
        }
    }
    //load volume control
    //single master volume for both sfx and music
    public void ClickToViewVolume()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        if (!volumeControl.active)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            volumeControl.SetActive(true);
        }

        if (storyText.enabled)
        {
            storyText.enabled = false;
        }

        if (controlsText.enabled)
        {
            controlsText.enabled = false;
        }
    }
}
