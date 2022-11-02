using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*Trigger zone for plane to end game*/
public class PlaneTriggerZone : MonoBehaviour
{
    public Text planeMessage;
    public PlayerCollision gameOver;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(Inventory.viralPathogen == 1 && Inventory.petrol == 1)
            {
                //Game Over screen Display
                //both viral strain and petrol should be in inventory
                gameOver.GameOver();
            }
            else if (Inventory.viralPathogen == 1 && Inventory.petrol == 0)
            {
                planeMessage.SendMessage("ShowHint", "I will need more petrol...I need check all the houses and find one fast");
            }
            else if (Inventory.viralPathogen == 0 && Inventory.petrol == 1)
            {
                planeMessage.SendMessage("ShowHint", "I can't go yet...I need the viral pathogen from the facility");
            }
            else
            {
                planeMessage.SendMessage("ShowHint", "Get the viral pathogen and get some petrol...I need to check those houses for petrol");
            }
        }
    }
}
