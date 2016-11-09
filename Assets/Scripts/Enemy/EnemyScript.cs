using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
    FOV fov;
    public LayerMask mask;
    public AudioClip[] sounds;
    public GameObject origin;
    private AudioSource aud;
    public float fireRate = 2f;
    private float nextFire;
    public GameObject bullet;
    public GameObject bulletPos;

   

    #region Health
    private float maxhealth = 100;
    public float currentHealth = 100;
    public float damage = 10;
    #endregion
    // Use this for initialization
    void Start()
    {
        nextFire = Time.time;
        fov = GetComponent<FOV>();
        aud = GetComponent<AudioSource>();
        currentHealth = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        OnDeath();
    }

    public void Shoot()
    {

        
        if (Time.time > nextFire)
        {
            //Debug.Log("Enemy is Shooting");
            aud.Play();
            GameObject rocket = (GameObject)Instantiate(bullet, bulletPos.transform.position, bullet.transform.rotation);
            
            rocket.GetComponentInChildren<Rigidbody>().AddForce(transform.forward * 750);
            //fov.target.GetComponent<PlayerMovement>().currentHealth -= 10;
            nextFire = Time.time + fireRate;

        }

    }


    public void OnDeath()
    {
        
        if (currentHealth < 0)
        {
            //blows up
            //death sound
            //destroys gameobject
            Destroy(gameObject);


        }
    }
}

