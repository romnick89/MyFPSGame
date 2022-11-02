using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]


/*Shooting and Reload related script */
public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform muzzleFlashParticle;
    //gun and shoot variables
    public int gunDamage = 1;
    public float fireRate = .25f;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Transform gunEnd;
    public AudioClip shootSound;
    public Rigidbody casingPrefab;
    private Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
    private LineRenderer laserLine;
    private float nextFire;
    //ammo variables
    private int currentAmmo;
    private int requiredAmmoOnReload;
    public Text currentAmmoText;
    public Text maxAmmoText;
    public Text reloadText;
    public AudioClip reloadAmmo;
    private bool isReloading = false;
    private float reloadTime;
    private float nextReload;

    private void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        fpsCam = GetComponent<Camera>();
        currentAmmo = 20;
        requiredAmmoOnReload = 0;
        reloadTime = 2.2f;
    }

    //Update is called once per frame
    void Update()
    {
        if (!MainMenu.isPause && !PlayerCollision.isGameOver)
        {
            if (currentAmmo > 0 && isReloading.Equals(false))
            {
                if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
                {
                    //find rifle object and play shoot animation
                    transform.Find("arms_assault_rifle_01").SendMessage("ShootAnim");

                    nextFire = Time.time + fireRate;
                    //reduce current ammo when firing 
                    currentAmmo--;
                    currentAmmoText.GetComponent<Text>().text = currentAmmo.ToString();
                    //count ammo required for loading
                    requiredAmmoOnReload++;

                    //get location of empty object shell locattion
                    GameObject shellLocation = transform.Find("shellLocation").gameObject;
                    //instatiate game object - shell casing
                    Rigidbody newCasing = Instantiate(casingPrefab, shellLocation.transform.position, shellLocation.transform.rotation) as Rigidbody;
                    newCasing.name = "Big_Casing_Prefab";



                    //instantiate muzzle flash in gunEnd location
                    Instantiate(muzzleFlashParticle, gunEnd.transform.position, Quaternion.identity);

                    //play shoot sound
                    gameObject.GetComponent<AudioSource>().PlayOneShot(shootSound);

                    StartCoroutine(ShotEffect());

                    Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

                    RaycastHit hit;
                    laserLine.SetPosition(0, gunEnd.position);

                    if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
                    {
                        laserLine.SetPosition(1, hit.point);

                        //Get reference to health script attached to the collider hit
                        ZombieEnemy health = hit.collider.GetComponent<ZombieEnemy>();
                        ZombieFemale health2 = hit.collider.GetComponent<ZombieFemale>();
                        ZombieBoss bossHealth = hit.collider.GetComponent<ZombieBoss>();
                        //reference to exploding gas tank when shot
                        GasTank hitTank = hit.collider.GetComponent<GasTank>();
                        if(hitTank  != null)
                        {
                            hitTank.GasTankHit();
                        }
                                               
                        if (health != null)
                        {
                            health.Damage(gunDamage);
                        }

                        if (health2 != null)
                        {
                            health2.Damage(gunDamage);
                        }

                        if (bossHealth != null)
                        {
                            bossHealth.Damage(gunDamage);
                        }

                        if (hit.rigidbody != null)
                        {
                            hit.rigidbody.AddForce(-hit.normal * hitForce);
                        }

                        
                    }
                    else
                    {
                        //set laser line position and origin
                        laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
                        //next fire is set
                        nextFire = Time.time + fireRate;
                    }
                }
            }
            else
            {
                //set text if gun requires reloading
                reloadText.SendMessage("ShowWeaponHint", "RELOAD");
            }
        }
        //reload
        ReloadFunction();
        //no ammo message is set
        if (Inventory.maxAmmo == 0 && currentAmmo == 0)
        {
            reloadText.SendMessage("ShowWeaponHint", "NO AMMO");
        }
        //scope function
        Scope();
    }
    
    private IEnumerator ShotEffect()
    {
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }
    //reloading check to prevent player doing other actions
    private IEnumerator Reloading(float seconds) 
    {
        isReloading = true;
        yield return new WaitForSeconds(seconds);
        isReloading = false;
        reloadText.GetComponent<Text>().enabled = false;
    }
    //set field of view to allow scope
    private void Scope()
    {
        if (Input.GetButton("Fire2"))
        {
            fpsCam.fieldOfView = 30f;
        }
        else
        {
            fpsCam.fieldOfView = 60f;
        }
    }
    //reload function
    private void ReloadFunction()
    {
        if (Inventory.maxAmmo > 0 && currentAmmo < 20)
        {
            if (Input.GetKeyDown(KeyCode.R) && Time.time > nextReload)
            {
                //find rifle object and play animation
                transform.Find("arms_assault_rifle_01").SendMessage("ReloadAnim");
                nextReload = Time.time + reloadTime;
                //start reloading IEnumarator
                StartCoroutine(Reloading(reloadTime));
                //allows reload if current ammo is less than max ammo specified
                if (requiredAmmoOnReload <= Inventory.maxAmmo)
                {
                    Inventory.maxAmmo -= requiredAmmoOnReload;
                    maxAmmoText.GetComponent<Text>().text = Inventory.maxAmmo.ToString();

                    currentAmmo += requiredAmmoOnReload;
                    currentAmmoText.GetComponent<Text>().text = currentAmmo.ToString();
                    requiredAmmoOnReload = 0;
                }
                //reload inventory ammo to current ammo even if required ammo is greater
                //set max ammo to zero and required ammo is reduced with the number of ammo reloaded
                if (requiredAmmoOnReload > Inventory.maxAmmo)
                {
                    currentAmmo += Inventory.maxAmmo;
                    currentAmmoText.GetComponent<Text>().text = currentAmmo.ToString();

                    requiredAmmoOnReload -= Inventory.maxAmmo;
                    Inventory.maxAmmo = 0;
                    maxAmmoText.GetComponent<Text>().text = Inventory.maxAmmo.ToString();

                }
            }
        }
    }
}
