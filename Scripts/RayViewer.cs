using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Ray viewer script*/
public class RayViewer : MonoBehaviour
{
    public float weaponRange = 50f;

    private Camera fpsCam;
    // Start is called before the first frame update
    void Start()
    {
        fpsCam = GetComponentInParent<Camera>();
    }

    // render line from gun when shooting
    void Update()
    {
        Vector3 lineOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
    }
}
