using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
/*Hover on text script*/
public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public AudioClip selectionSound;
    public Text text;
    public void OnPointerEnter(PointerEventData eventData)
    {
        //set font to bold and play audio
        text.GetComponent<Text>().fontStyle = FontStyle.Bold;
        GetComponent<AudioSource>().PlayOneShot(selectionSound);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //return to normal text on cursor exit
        text.GetComponent<Text>().fontStyle = FontStyle.Normal;       
    }
}
