using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPlayerControlOn : MonoBehaviour {
	PlayerController controller;
	public float waitTimer;
	float startOfWait;

	// Use this for initialization
	void Start () {
		controller = GetComponent<PlayerController>();
		controller.enabled = false;
		startOfWait = waitTimer;
	}
	
	// Update is called once per frame
	void Update () {
		if(controller.enabled == false) {
			if(waitTimer > 0) {
				waitTimer -= Time.deltaTime;
			} else {
				controller.enabled = true;
			}
		} 
	}
}
