using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFalls : MonoBehaviour
{
    [SerializeField] private Transform fallsParticle;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(fallsParticle, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
