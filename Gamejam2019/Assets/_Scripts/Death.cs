using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Death : MonoBehaviour {
	public GameObject deathScreen;
	public float fadeInTimer;

	Image image;


	public void LoadDeathScene(){
		SceneManager.LoadScene("DeathScene", LoadSceneMode.Single);

	}

	private void Start(){
		GrabScreen();
	}

	public void GrabScreen(){
		deathScreen = GameObject.FindGameObjectWithTag("DeathScreen");
	}

	public void FadeIn(){

		StartCoroutine(Fade());
	}

	public void Reset(){
		image.color = new Vector4(image.color.r, image.color.g, image.color.b, 0);
	}

	IEnumerator Fade(){
		if(deathScreen != null) {
			image = deathScreen.GetComponentInChildren<Image>();
			if(image != null) {
				while(image.color.a < 1) {
					var tmp = image.color;
					tmp.a += Time.deltaTime * fadeInTimer;
					image.color = tmp;
					//yield return null;
				}
			}
		}
		yield return null;
	}
}
