using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(AudioSource))]
/*Big angry Boss zombie Script*/
public class ZombieBoss : MonoBehaviour
{
    [SerializeField] private Transform hitParticle;
    //movement, idle, attack, hit and death script for object
    private GameObject target;
    NavMeshAgent agent;
    public float distanceFromTarget = 50;
    Animator animator;
    public int currentHealth = 8;
    private bool isHit = false;
    private float distance;
    //drop item upon death
    public GameObject dropItem;
    //sound variable for each object condition
    public AudioClip attackSound;
    public AudioClip damageSound;
    public AudioClip idleSound;
    public AudioClip runSound;
    public AudioClip deathSound;
    private AudioSource audio;
    private bool isSoundPlaying = false;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        target = GameObject.Find("FPSController");
        audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        //calculate distance of target and this object and store it to a float
        distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance <= distanceFromTarget && currentHealth >= 1 && !isHit && distance > 3.7f)
        {
            //get target direction and store it to new Vector 3
            Vector3 targetDirection = transform.position - target.transform.position;
            //run towards the target direction
            Vector3 newPosition = transform.position - targetDirection;
            audio.clip = runSound;
            if (!audio.isPlaying && isSoundPlaying.Equals(false))
            {
                audio.Play();
            }
            if (MainMenu.isPause)
            {
                audio.Pause();
            }
            animator.Play("Run");
            agent.SetDestination(newPosition);
        }
        //attack when object is close to target
        if (distance <= 3.6f && currentHealth >= 1 && !isHit)
        {
            audio.clip = attackSound;
            if (!audio.isPlaying && isSoundPlaying.Equals(false))
            {
                StartCoroutine(PlaySounds(2.5f));
            }

            if (MainMenu.isPause)
            {
                audio.Pause();
            }
            animator.Play("Attack");
            agent.SetDestination(gameObject.transform.position);

        }
        //idle if target distance is greater than specified
        if (distance >= distanceFromTarget && currentHealth >= 1 && !isHit)
        {
            audio.clip = idleSound;
            if (!audio.isPlaying && isSoundPlaying.Equals(false))
            {
                audio.Play();
            }
            if (MainMenu.isPause)
            {
                audio.Pause();
            }
            agent.SetDestination(gameObject.transform.position);
            animator.Play("Idle");
        }
        //function upon death of this object
        if (currentHealth <= 0)
        {
            audio.clip = deathSound;
            if (!audio.isPlaying && isSoundPlaying.Equals(false))
            {
                StartCoroutine(PlaySounds(5f));
            }

            if (MainMenu.isPause)
            {
                audio.Pause();
            }

            agent.SetDestination(gameObject.transform.position);
            animator.Play("Death");
        }
        //function upon object is hit
        if (isHit && currentHealth > 0)
        {
            audio.clip = damageSound;
            if (!audio.isPlaying && isSoundPlaying.Equals(false))
            {
                StartCoroutine(PlaySounds(2.5f));
            }

            if (MainMenu.isPause)
            {
                audio.Pause();
            }

            StartCoroutine(HitAnimation(2));
            agent.SetDestination(gameObject.transform.position);
        }
    }
    //function when this object is shot by player
    public void Damage(int damageAmount)
    {
        isHit = true;
        currentHealth -= damageAmount;
        //blood particle instatitate
        Vector3 bloodPosition = new Vector3(0f, 2.5f, 0f);
        Instantiate(hitParticle, transform.position + bloodPosition, Quaternion.identity * Quaternion.Euler(0, 320f, 0));
        //set distance from target when attacked to chase
        distanceFromTarget = 500;

        if (currentHealth <= 0)
        {

            StartCoroutine(DeactivateObject(4, gameObject));
        }
    }
    //remove object
    private IEnumerator DeactivateObject(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
        //drop item on death location
        Vector3 dropLocation = new Vector3(0f, 2f, 0f);
        Instantiate(dropItem, gameObject.transform.position + dropLocation, gameObject.transform.rotation);
    }
    //hit animation
    private IEnumerator HitAnimation(int seconds)
    {
        animator.Play("Hit");
        yield return new WaitForSeconds(seconds);
        isHit = false;
    }
    //play sound depending on the objects condition
    private IEnumerator PlaySounds(float seconds)
    {
        isSoundPlaying = true;
        audio.Play();
        yield return new WaitForSeconds(seconds);
        isSoundPlaying = false;
    }
}
