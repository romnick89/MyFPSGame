using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(AudioSource))]
/*Zombie enemy script*/
public class ZombieEnemy : MonoBehaviour
{
    [SerializeField] private Transform hitParticle;
    //movement, idle, attack and death variables
    private GameObject target;
    NavMeshAgent agent;
    public float distanceFromTarget = 100;
    Animator animator;
    public int currentHealth = 3;
    private bool isHit = false;
    private float distance;
    //drop item variable of enemy 
    public GameObject dropItem;
    //sound effects variables
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
        //set target for this object
        target = GameObject.Find("FPSController");
        audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        //calculate distance from target to this object as single float
        distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance <= distanceFromTarget && currentHealth >= 1 && !isHit && distance > 3.7f)
        {
            //calculate targets direction 
            Vector3 targetDirection = transform.position - target.transform.position;
            //run towards the target
            Vector3 newPosition = transform.position - targetDirection;

            audio.clip = runSound;
            if (!audio.isPlaying && isSoundPlaying.Equals(false))
            {
                audio.Play();
            }
            if(MainMenu.isPause)
            {
                audio.Pause();
            }
            //play run animation
            animator.Play("Run");
            agent.SetDestination(newPosition);
        }
        //attack when condition is met
        if (distance <= 3.7f && currentHealth >= 1 && !isHit)
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
            //play attack animation
            animator.Play("Attack");
            agent.SetDestination(gameObject.transform.position);
        }
        //enemy idle depending on the distance set from the target
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
            //idle animation
            agent.SetDestination(gameObject.transform.position);
            animator.Play("Idle");
        }
        //death function upon objects death
        if (currentHealth <= 0)
        {
            audio.clip = deathSound;
            if (!audio.isPlaying && isSoundPlaying.Equals(false))
            {
                StartCoroutine(PlaySounds(4f));
            }

            if (MainMenu.isPause)
            {
                audio.Pause();
            }

            agent.SetDestination(gameObject.transform.position);
            animator.Play("Death");
        }
        //run function when object is hit
        if (isHit && currentHealth > 0)
        {
            audio.clip = damageSound;
            if (!audio.isPlaying && isSoundPlaying.Equals(false))
            {
                StartCoroutine(PlaySounds(2f));
            }

            if (MainMenu.isPause)
            {
                audio.Pause();
            }

            StartCoroutine(HitAnimation(2));
            agent.SetDestination(gameObject.transform.position);
        }       
    }
    //damage function when shot by player
    public void Damage(int damageAmount)
    {
        isHit = true;
        currentHealth -= damageAmount;

        Vector3 bloodPosition = new Vector3(0f, 2.5f, 0f);
        Instantiate(hitParticle, transform.position + bloodPosition, Quaternion.identity * Quaternion.Euler(0, 320f, 0));
        //set new target distance to chase
        distanceFromTarget = 500;

        if (currentHealth <= 0)
        {

            StartCoroutine(DeactivateObject(4, gameObject));
        }
    }
    //remove object upon death
    private IEnumerator DeactivateObject(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
        //instatiate object on object's death location
        Vector3 dropLocation = new Vector3(0f, 2f, 0f);
        Instantiate(dropItem, gameObject.transform.position + dropLocation, gameObject.transform.rotation);
    }
    //play hit animation
    private IEnumerator HitAnimation(int seconds)
    {
        animator.Play("Hit");
        yield return new WaitForSeconds(seconds);
        isHit = false;
    }
    //rotate sound effects by objects current condition
    private IEnumerator PlaySounds(float seconds)
    {
        isSoundPlaying = true;
        audio.Play();
        yield return new WaitForSeconds(seconds);
        isSoundPlaying = false;      
    }

}
