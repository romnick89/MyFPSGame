using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Ammo object script*/
public class Ammo : MonoBehaviour
{
    public float rotationSpeed = 200.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
    }
    //run function on player collision
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && Inventory.maxAmmo < 180)
        {
            other.gameObject.SendMessage("GotAmmo");            
            Destroy(gameObject);
        }
        else
        {
            //send message to invntory script
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.SendMessage("MaxAmmoMessage");
            }           
        }
    }
}
