using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
/*Access animation Script*/
public class GunAnimation : MonoBehaviour
{
    Animator animator;
    public AudioClip reloadAmmo;
    public AudioClip missionVoice;


    private void Awake()
    {
        animator = GetComponent<Animator>();       
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(reloadAmmo);
        gameObject.GetComponent<AudioSource>().PlayOneShot(missionVoice);
    }

    // Gun animation on movement
    void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            animator.SetTrigger("Walk");
        }
        else
        {
            animator.ResetTrigger("Walk");
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetTrigger("Run");
        }
        else
        {
            animator.ResetTrigger("Run");
        }
    }
    //shooting animation when fire is triggered
    //play recoil
    public void ShootAnim()
    {
        animator.Play("Fire");
    }
    //reload animation
    public void ReloadAnim()
    {
        animator.Play("Reload Ammo Left");
        gameObject.GetComponent<AudioSource>().PlayOneShot(reloadAmmo);
    }
}
