using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {

	// Use this for initialization
	public void Play () {
        SceneManager.LoadScene(1);
	}
	
	// Update is called once per frame
	public void Exit () {
        Application.Quit();
	}
}
