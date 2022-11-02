using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Gate key Script*/
public class Key : MonoBehaviour
{
    public float rotationSpeed = 100.0f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
    }
    //function trigger when collides with player
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.SendMessage("GotKey");
            Destroy(gameObject);
        }
    }
}
