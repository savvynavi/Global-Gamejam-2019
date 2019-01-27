using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHit : MonoBehaviour {
	RandomLevelLoad rndLvlLoad;
	// Use this for initialization
	void Start () {
		rndLvlLoad = GameObject.FindGameObjectWithTag("Loader").GetComponent<RandomLevelLoad>();

	}

	private void OnCollisionEnter2D(Collision2D collision){

		if(collision.gameObject.layer == 8) {
			rndLvlLoad.NextLevel();

		} else {
			Destroy(collision.gameObject);

		}
	}
}
