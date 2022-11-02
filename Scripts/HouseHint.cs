using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*House hint script*/
public class HouseHint : MonoBehaviour
{
    public Text petrolHint;
    public GameObject petrolPrefab;
    private bool spawnPetrol;
    // Start is called before the first frame update
    void Start()
    {
        spawnPetrol = false;
    }
    //run function on player trigger
    private void OnTriggerEnter(Collider other)
    {
        petrolHint.SendMessage("ShowHint", "hmmm...blood...There is something written in the chimney...?");
        //instantiate object petrol in specified location
        if (spawnPetrol.Equals(false))
        {
            Vector3 petrolLocation = new Vector3(654.8278f, 64.89f, 254.9f);
            Instantiate(petrolPrefab, petrolLocation, petrolPrefab.transform.rotation);

            spawnPetrol = true;
        }
        
    }
}
