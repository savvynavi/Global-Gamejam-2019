using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour {

	RandomLevelLoad RandomLevelLoad;

	// Use this for initialization
	void Start () {
		RandomLevelLoad = GameObject.FindGameObjectWithTag("Loader").GetComponent<RandomLevelLoad>();
	}

	private void OnCollisionEnter2D(Collision2D collision){
		RandomLevelLoad.NextLevel();
	}
}
