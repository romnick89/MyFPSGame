using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*Inventory script for player*/
public class Inventory : MonoBehaviour
{
    public static int gateKey;
    public static int id_Card;
    public static int maxAmmo;
    public static int viralPathogen;
    public static int petrol;
    private int ammoLimit;
    public Text message;
    public Text maxAmmoText;
    public AudioClip ammoPickupSound;
    public AudioClip itemPickup;
    public RawImage keyGUI;
    public RawImage IDCardGUI;
    public RawImage fuelGUI;
    public GameObject virusCaseUI;
    public GameObject flashlight;
    public AudioClip flashLightSound;
    public AudioClip keyItemSound;

    // Start is called before the first frame update
    void Start()
    {
        id_Card = 0;
        gateKey = 0;
        maxAmmo = 180;
        ammoLimit = 180;
        viralPathogen = 0;
        petrol = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //toggle flashlight on or off
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!flashlight.activeSelf)
            {
                GetComponent<AudioSource>().PlayOneShot(flashLightSound);
                flashlight.SetActive(true);
            }
            else
            {
                GetComponent<AudioSource>().PlayOneShot(flashLightSound);
                flashlight.SetActive(false);
            }
        }
    }
    //code fires up when collided with the gate key
    public void GotKey() 
    {
        GetComponent<AudioSource>().PlayOneShot(itemPickup);
        gateKey = 1;
        message.SendMessage("ShowHint", "I got the key. I should go back to the gate.");
        
        if (!keyGUI.enabled)
        {
            keyGUI.enabled = true;
        }
    }
    //code fires up when collided with the ID card
    public void GotIDCard()
    {
        GetComponent<AudioSource>().PlayOneShot(itemPickup);
        id_Card = 1;
        message.SendMessage("ShowHint", "I got the ID card. This should open that door");

        if (!IDCardGUI.enabled)
        {
            IDCardGUI.enabled = true;
        }
    }
    //code fires up on ammo pickup
    public void GotAmmo()
    {
        GetComponent<AudioSource>().PlayOneShot(ammoPickupSound);
        
        if (maxAmmo < ammoLimit)
        {
            if (maxAmmo <= 160)
            {
                //add ammo
                maxAmmo += 20;
                maxAmmoText.GetComponent<Text>().text = maxAmmo.ToString();
            }
            else
            {
                maxAmmo = 180;
                maxAmmoText.GetComponent<Text>().text = maxAmmo.ToString();
            }
        }                 
    }
    //display message when health is full send to text hint script
    public void MaxHealth()
    {
        message.SendMessage("ShowHint", "Health is full.");
    }
    //display message when ammo is full send to text hint script
    public void MaxAmmoMessage()
    {
        message.SendMessage("ShowHint", "You have maximum ammunition.");
    }
    //code firesup when viral strain object collision
    public void GotVirus()
    {
        GetComponent<AudioSource>().PlayOneShot(keyItemSound);
        viralPathogen = 1;
        if (!virusCaseUI.activeSelf)
        {
            virusCaseUI.SetActive(true);
        }
        
        message.SendMessage("ShowHint", "This is what I came for...Better get out of here");
    }
    //code fires up on petrol object collision 
    public void GotPetrol()
    {
        GetComponent<AudioSource>().PlayOneShot(keyItemSound);
        petrol = 1;
        message.SendMessage("ShowHint", "I got the petrol for the plane.");
        if (!fuelGUI.enabled)
        {
            fuelGUI.enabled = true;
        }
    }
}
