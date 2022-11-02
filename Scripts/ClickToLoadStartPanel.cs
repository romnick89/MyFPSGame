using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Click to start panel script*/
public class ClickToLoadStartPanel : MonoBehaviour
{
    public GameObject startPanel;
    //function run when start button is clicked
    public void ClickToStartPanel()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        if (!startPanel.active)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            startPanel.SetActive(true);
        }
    }
    //function run when cancel button is clicked
    public void ClickToClosePanel()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        if (startPanel.active)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            startPanel.SetActive(false);
        }
    }
}
