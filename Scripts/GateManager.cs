using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Gate manager script*/
public class GateManager : MonoBehaviour
{
    Animator animator;
    public AudioClip gateOpenSound;
    public AudioClip gateCloseSound;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    //gate open and sound function
    public void GateOpen()
    {
        GetComponent<AudioSource>().PlayOneShot(gateOpenSound);
        StartCoroutine(GateOpenning(1));
    }
    //gate closing and sound function
    public void GateClose()
    {
        GetComponent<AudioSource>().PlayOneShot(gateCloseSound);
        StartCoroutine(GateClosing(1));
    }
    //gate openning animation
    private IEnumerator GateOpenning(int seconds)
    {
        animator.Play("GateOpenning");
        yield return new WaitForSeconds(seconds);
        animator.Play("GateOpen");
    }
    //gate closing animation
    private IEnumerator GateClosing(int seconds)
    {
        animator.Play("GateClosing");
        yield return new WaitForSeconds(seconds);
        animator.Play("GateClose");
    }
}
