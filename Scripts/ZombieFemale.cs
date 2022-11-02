using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(AudioSource))]
/*Zombie female script*/
public class ZombieFemale : MonoBehaviour
{
    [SerializeField] private Transform hitParticle;
    //zombie female variables for movement, attack, idle and death
    private GameObject target;
    NavMeshAgent agent;
    public float distanceFromTarget = 200;
    Animator animator;
    public int currentHealth = 3;
    private bool isHit = false;
    private float distance;
    //drop item specified
    public GameObject dropItem;
    //sound effect variables
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
        //set target player
        target = GameObject.Find("FPSController");
        audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        //get float distance from target postion to this 
        distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance <= distanceFromTarget && currentHealth >= 1 && !isHit && distance > 3.7f)
        {
            //set target direction 
            Vector3 targetDirection = transform.position - target.transform.position;
            //go to target location
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
            //play run animation
            animator.Play("Run");
            agent.SetDestination(newPosition);
        }
        // trigger attack
        if (distance <= 3.7f && currentHealth >= 1 && !isHit)
        {
            audio.clip = attackSound;
            if (!audio.isPlaying && isSoundPlaying.Equals(false))
            {
                StartCoroutine(PlaySounds(4f));
            }

            if (MainMenu.isPause)
            {
                audio.Pause();
            }

            animator.Play("Attack");
            agent.SetDestination(gameObject.transform.position);

        }
        //trigger idle depending on distance from target set
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
        //trigger death when health is less than or equal to zero
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
        //on enemy hit
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
    //damage function
    public void Damage(int damageAmount)
    {
        isHit = true;
        currentHealth -= damageAmount;

        Vector3 bloodPosition = new Vector3(0f, 2.5f, 0f);
        Instantiate(hitParticle, transform.position + bloodPosition, Quaternion.identity * Quaternion.Euler(0, 320f, 0));
        //set target distance from target to chase when shot
        distanceFromTarget = 500;

        if (currentHealth <= 0)
        {
            StartCoroutine(DeactivateObject(4, gameObject));
        }
    }
    //deactivate object
    //run function when object dies
    private IEnumerator DeactivateObject(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);

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
    //function to check sound
    //rotate sound effects depending on object current condition
    private IEnumerator PlaySounds(float seconds)
    {       
       isSoundPlaying = true;
       audio.Play();
       yield return new WaitForSeconds(seconds);
       isSoundPlaying = false;       
    }
}
