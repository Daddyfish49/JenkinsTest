using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class FireScript : MonoBehaviour
{
    private Image crosshair;
    public AudioSource shootsound;
    public LineRenderer laser;
    public float fireRate = 0.7f;
    private float nextFire;

    RaycastHit hit;
    // Use this for initialization
    void Start()
    {
        crosshair = GameObject.FindGameObjectWithTag("Crosshair").GetComponent<Image>();
        shootsound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        Crosshair();
        Shoot();

    }

    void Crosshair()
    {
        //crosshair goes red when looking at enemy
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.tag == "Enemy")
            {
                crosshair.color = Color.red;
            }
            else
            {
                crosshair.color = Color.white;

            }
        }
    }

    void Shoot()
    {
        if (Time.time > nextFire - 0.4f)
        {
            laser.enabled = false;
        }
        if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.tag == "Enemy")
                {

                    Debug.Log("Hit enemy");
                    hit.collider.gameObject.GetComponentInParent<EnemyScript>().currentHealth -= 34;
                    //damage to enemies
                }
            }
            //creates firerate
            nextFire = Time.time + fireRate;
            laser.enabled = true;
            shootsound.Play();


        }
    }



}
