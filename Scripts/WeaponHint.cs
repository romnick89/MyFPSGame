using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*Weapon hint script*/
public class WeaponHint : MonoBehaviour
{
    //send message function to GUI`
    public void ShowWeaponHint(string message)
    {
        gameObject.GetComponent<Text>().text = message;
        if (!gameObject.GetComponent<Text>().enabled)
        {
            gameObject.GetComponent<Text>().enabled = true;
        }
    }
}
