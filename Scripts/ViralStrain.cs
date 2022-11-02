using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Viral Strain Script*/
public class ViralStrain : MonoBehaviour
{
    public float rotationSpeed = 100.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
    }
    //on player trigger function 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //send and run function on inventory script
            other.gameObject.SendMessage("GotVirus");
            Destroy(gameObject);
        }
    }
}
