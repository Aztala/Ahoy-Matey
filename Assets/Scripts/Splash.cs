using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour {

	float timer = 5f;
	float elapsed = 0f;
	bool SoundPlayed = false;
	AudioSource au;
	//public LevelManager LM;


	// Use this for initialization
	void Start () {
		au = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		elapsed += Time.deltaTime;

		if (elapsed >= timer) {
			
			//LM.LoadLevel (1);
			SceneManager.LoadScene (1);
			//Application.LoadLevel (1); // Old fashion way
		}
		else if (elapsed >= timer - 2f && !SoundPlayed)
		{
			SoundPlayed = true;
			au.Play();
		}
	}
}
