using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Petrol object script*/
public class Petrol : MonoBehaviour
{
    public float rotationSpeed = 100.0f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
    }
    //trigger function on player collision
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.SendMessage("GotPetrol");
            Destroy(gameObject);
        }
    }
}
