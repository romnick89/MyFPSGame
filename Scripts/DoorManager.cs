using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class DoorManager : MonoBehaviour
{
    Animator animator;
    public AudioClip doorOpenSound;
    public AudioClip doorShutSound;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoorOpen()
    {
        GetComponent<AudioSource>().PlayOneShot(doorOpenSound);
        StartCoroutine(DoorOpenning(1));
    }

    public void DoorClose()
    {
        GetComponent<AudioSource>().PlayOneShot(doorShutSound);
        StartCoroutine(DoorClosing(1));
    }

    private IEnumerator DoorOpenning(int seconds)
    {
        animator.Play("DoorOpenning");       
        yield return new WaitForSeconds(seconds);
        animator.Play("DoorOpen");
    }

    private IEnumerator DoorClosing(int seconds)
    {
        animator.Play("DoorClosing");
        yield return new WaitForSeconds(seconds);
        animator.Play("DoorClose");
    }

}
