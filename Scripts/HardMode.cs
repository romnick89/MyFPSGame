using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Hard mode script*/
public class HardMode : MonoBehaviour
{
    public Light nightMode;
    public GameObject spawnZombie;


    // Start is called before the first frame update
    // activate hard mode settings
    void Start()
    {
        if (ClickToLoadAsyncHard.hardMode == 1)
        {
            //night mode activate
            if (nightMode.enabled)
            {
                nightMode.enabled = false;
            }
            //zombie spawner activate
            spawnZombie.SetActive(true);
        }
        

    }
}
