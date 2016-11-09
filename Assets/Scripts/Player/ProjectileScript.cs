using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour
{
    private Rigidbody rb;
    private LookScript cam;
    private PlayerMovement player;

    public float look;
    public ParticleSystem jumpParticle;
    public AudioSource shootsound;
    // Use this for initialization
    void Start()
    {
        shootsound = GameObject.FindGameObjectWithTag("Gun").GetComponent<AudioSource>();
        rb = GetComponentInParent<Rigidbody>();
        cam = GetComponentInParent<LookScript>();
        player = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        Projectile();
        if (player.isCannon)
        {
            jumpParticle.gameObject.SetActive(false);
        }

    }

    // && Time.time > nextFire)
    //    {
    //       //creates firerate
    //     nextFire = Time.time + fireRate;

    void Projectile()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && cam.pitch > 0 && player.isCannon)
        {
            //Debug.Log("Shoot player");
            //freeze player movement control but mouse still works
            //shoots forward in addforce with .up
            //multiply force with mouse.y to make it go further when you are looking higher up
            jumpParticle.gameObject.SetActive(true);
            if (cam.pitch > 80)
            {
                rb.AddForce((transform.up * (1 + (cam.pitch / 15)) + transform.forward * (4 + (cam.pitch / 6))), ForceMode.Impulse);
            }
            else if (cam.pitch > 50)
            {
                rb.AddForce((transform.up * (1 + (cam.pitch / 13)) + transform.forward * (4 + (cam.pitch / 6))), ForceMode.Impulse);
            }
            else if (cam.pitch > 25)
            {
                rb.AddForce((transform.up * (1 + (cam.pitch / 10)) + transform.forward * (4 + (cam.pitch / 4))), ForceMode.Impulse);
            }

            else if (cam.pitch > 0)
            {
                jumpParticle.gameObject.SetActive(false);
                rb.AddForce((transform.up * (1 + (cam.pitch / 10)) + transform.forward * (4 + (cam.pitch / 4))), ForceMode.Impulse);
            }//bool to restrict player movement
            player.isCannon = false;
            shootsound.Play();
        }


    }
}
