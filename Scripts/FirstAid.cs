using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*First aid to replenish health script*/
public class FirstAid : MonoBehaviour
{
    public float rotationSpeed = 200.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
    }
    //function when player collides with object
    private void OnTriggerEnter(Collider other)
    {
        //run function if condition is met
        //restore health function in player collision script
        if (other.gameObject.tag == "Player" && PlayerCollision.currentHealth < PlayerCollision.maxHealth && PlayerCollision.currentHealth != 0)
        {            
            Destroy(gameObject);
            other.gameObject.SendMessage("RestoreHealth");
        }
        else
        {
            //run function in inventory script and max health text
            if(other.gameObject.tag == "Player")
            {
                other.gameObject.SendMessage("MaxHealth");
            }           
        }
    }
}
