using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour {
    private float maxhealth = 100;
    public float currentHealth;
    public float damage = 10;
    private Text healthtxt;
    // Use this for initialization
    void Start () {
        healthtxt = GameObject.FindGameObjectWithTag("Healthtxt").GetComponent<Text>();
        currentHealth = maxhealth;
    }
	
	// Update is called once per frame
	void Update () {
        OnDeath();
        healthtxt.text = currentHealth.ToString();
	}

    void OnDeath()
    {
        if (currentHealth <= 0) {
            Application.LoadLevel(1);
        }
        //death screen
        //respawn
    }
}
