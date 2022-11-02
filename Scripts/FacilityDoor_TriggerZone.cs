using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*Facility Door Trigger Zone Script*/
public class FacilityDoor_TriggerZone : MonoBehaviour
{
    public AudioClip lockedSound;
    public AudioClip doorLockedVoice;
    public Text doorMessage;
    public Light doorLight;
    private bool spawnInfected = false;
    public GameObject mutantBoss;
    public GameObject mutantBoss2;
    //on trigger collider with player
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //open facility door on player enter trigger zone
            //player must hold id card
            if (Inventory.id_Card == 1)
            {
                transform.Find("Door").SendMessage("DoorOpen");
                doorLight.color = Color.green;
                //set active GUI ID card image 
                if (GameObject.Find("ID_CardImage"))
                {
                    Destroy(GameObject.Find("ID_CardImage"));
                }
            }
            else
            {
                //send message to GUI text hint
                doorMessage.SendMessage("ShowHint", "hmmm...Maybe one of the infected staff nearby has the keycard for this facility.");
                //play lock sound
                transform.Find("Door").GetComponent<AudioSource>().PlayOneShot(lockedSound);
                //play lock voice sound
                transform.Find("Door").GetComponent<AudioSource>().PlayOneShot(doorLockedVoice);
                //spawn two zombies
                //one zombie boss holds the key
                if (spawnInfected.Equals(false))
                {
                    Vector3 bossLocation = new Vector3(784.3791f, 36.20683f, 482.588f);
                    Vector3 bossLocation2 = new Vector3(803.81f, 36.2f, 482.71f);

                    Instantiate(mutantBoss, bossLocation, mutantBoss.transform.rotation);
                    Instantiate(mutantBoss2, bossLocation2, mutantBoss2.transform.rotation);

                    spawnInfected = true;
                }
            }   
        }
    }
    //close facility door on player exit the trigger zone
    //player must hold the id card
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Inventory.id_Card == 1)
            {
                transform.Find("Door").SendMessage("DoorClose");
            }
        }
    }
}
