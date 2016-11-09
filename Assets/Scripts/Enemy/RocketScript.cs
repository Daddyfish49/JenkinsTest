using UnityEngine;
using System.Collections;

public class RocketScript : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        
        //transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            //damage player
            col.GetComponent<PlayerHealth>().currentHealth -= 34;
            //Debug.Log("hit player");
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
