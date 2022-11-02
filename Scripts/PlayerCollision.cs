using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
/*Player Collision Script*/
public class PlayerCollision : MonoBehaviour
{
    public static int currentHealth;
    public static int maxHealth = 20;
    public static bool isGameOver = false;
    public HealthBar healthBar;
    public GameObject normalModeTryButton;
    public GameObject hardModeTryButton;
    public GameObject player;
    public GameObject takeDamageImage;
    public AudioClip biteSound;
    public AudioClip rightSound;
    public AudioClip clawSound;
    public AudioClip healthPickupSound;

    public GameObject gameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(maxHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        //zombie enemy attack triggered
        if (other.gameObject.tag == "zombieRight")
        {
            //Debug.Log("You got slap in the face!!!!");
            GetComponent<AudioSource>().PlayOneShot(rightSound);
            StartCoroutine(DamageEffects());
            TakeDamage(2);           
        }
        //zombie female attack triggered
        if (other.gameObject.tag == "zombieBite")
        {
            //Debug.Log("You got bitten in the face!!!!");
            GetComponent<AudioSource>().PlayOneShot(biteSound);
            StartCoroutine(DamageEffects());
            TakeDamage(2);
            
        }       
        //zombie boss attack triggered
        if (other.gameObject.tag == "zombieClaw")
        {
            //Debug.Log("You got clawed by the boss!!!!");
            GetComponent<AudioSource>().PlayOneShot(clawSound);
            StartCoroutine(DamageEffects());
            TakeDamage(4);
            
        }

        //Game Over function run when health is zero or lower
        if (currentHealth <= 0)
        {
            //gameObject.GetComponent<AudioSource>().PlayOneShot(deathSound);
            GameOver();
        }
    }
    //function when player takes damage
    private void TakeDamage(int damage)
    {       
        currentHealth -= damage;
        //set health bar similar to current health
        healthBar.SetHealth(currentHealth);
    }
    //function run on health item pickup 
    public void RestoreHealth()
    {
        GetComponent<AudioSource>().PlayOneShot(healthPickupSound);
        currentHealth += 2;
        healthBar.SetHealth(currentHealth);
    }
    //run function on game over
    public void GameOver()
    {
        //display game over modal screen
#pragma warning disable CS0618 // Type or member is obsolete
        if (!gameOverScreen.active)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            isGameOver = true;
            gameOverScreen.SetActive(true);
            
            player.GetComponent<FirstPersonController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
           
            Time.timeScale = 0f;
            
            //set try again button active if on hard mode
            if (ClickToLoadAsyncHard.hardMode == 1)
            {
#pragma warning disable CS0618 // Type or member is obsolete
                if (!hardModeTryButton.active)
#pragma warning restore CS0618 // Type or member is obsolete
                {
                    hardModeTryButton.SetActive(true);                   
                }
            }
            //set try again button active if on normal mode
            if (ClickToLoadAsync.normalMode == 1)
            {
#pragma warning disable CS0618 // Type or member is obsolete
                if (!normalModeTryButton.active)
#pragma warning restore CS0618 // Type or member is obsolete
                {
                    normalModeTryButton.SetActive(true);                    
                }
            }
        }
    }
    //set damage effects when hit by enemy
    IEnumerator DamageEffects()
    {        
        takeDamageImage.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        takeDamageImage.SetActive(false);
    }
}
