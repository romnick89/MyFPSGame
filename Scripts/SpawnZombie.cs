using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Spawn a zombie enemy script with specified time*/
public class SpawnZombie : MonoBehaviour
{
    public GameObject spawnZombie;
    private float spawnTime = 60f;
    private float nextSpawn;
    // Start is called before the first frame update
    void Start()
    {
        nextSpawn = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        //spawn zombie every minute
        if (Time.time > nextSpawn)
        {
            SummonZombie();
            nextSpawn = Time.time + spawnTime;
        }
    }

    //spawn zombie in location specified
    private void SummonZombie()
    {
        Vector3 zombieLocation = new Vector3(558.91f, 30.681f, 548.96f);
        Instantiate(spawnZombie, zombieLocation, spawnZombie.transform.rotation);
    }
}
