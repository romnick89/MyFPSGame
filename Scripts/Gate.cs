using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*Gate trigger script*/
public class Gate : MonoBehaviour
{
    Animator animator;
    public Text gatemessage;
    public GameObject keyPrefab;
    public GameObject mutantBoss;
    private bool spawnKey = false;
    public AudioClip gateLockedSound;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // trigger if player collides the gate trigger zone
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //open gate if key is in the inventory
            if (Inventory.gateKey == 1)
            {
                transform.Find("Gate").SendMessage("GateOpen");
                if (GameObject.Find("KeyImage"))
                {
                    Destroy(GameObject.Find("KeyImage"));
                }
            }
            else
            {
                //show message if does not have key in inventory
                gatemessage.SendMessage("ShowHint", "Hmmm...What or who could have done this...There is a note here. I guess the gate key is in the waterfalls.");
                transform.Find("Gate").GetComponent<AudioSource>().PlayOneShot(gateLockedSound);
                //instantiate key prefab in specified location
                if (spawnKey.Equals(false))
                {
                    Vector3 keyLocation = new Vector3(192, 36, 214);
                    Instantiate(keyPrefab, keyLocation, keyPrefab.transform.rotation);
                    Instantiate(mutantBoss, keyLocation, mutantBoss.transform.rotation);
                    
                    spawnKey = true;
                }                
            }
        }
    }
    //run function on trigger exit
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Inventory.gateKey == 1)
            {
                transform.Find("Gate").SendMessage("GateClose");
            }
        }
    }
}
