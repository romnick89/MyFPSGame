using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
/*Gas tank script*/
public class GasTank : MonoBehaviour
{
    [SerializeField] private Transform explosion;
    public AudioClip exlodeSound;
    public AudioClip explodeSound2;

    public void GasTankHit()
    {
        StartCoroutine(HitTank(1));
    }
    //destroy objects specified when shot
    //instatiate explosion and sound explosion
    private IEnumerator HitTank(int seconds)
    {
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        gameObject.GetComponent<AudioSource>().PlayOneShot(exlodeSound);
        yield return new WaitForSeconds(seconds);
        gameObject.GetComponent<AudioSource>().PlayOneShot(explodeSound2);
        Destroy(gameObject);       
        if (GameObject.Find("Debries"))
        {
            Destroy(GameObject.Find("Debries"));
        }
    }
}
