using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Tidy object script
 mostly used in instatiated particles*/
public class TidyObjects : MonoBehaviour
{
    public float timeBeforeDestroy = 2.0f; 
    // Start is called before the first frame update
    void Start()
    {
        //destroy object with time specified
        Destroy(gameObject, timeBeforeDestroy);
    }
}
