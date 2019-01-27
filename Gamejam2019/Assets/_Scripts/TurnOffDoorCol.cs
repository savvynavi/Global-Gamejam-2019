using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffDoorCol : MonoBehaviour
{
	Collider2D col;
	public float waitTimer;
	float startOfWait;

	// Use this for initialization
	void Awake()
	{
		col = GetComponent<Collider2D>();
		col.enabled = false;
		startOfWait = waitTimer;
	}

	void Update()
	{
		if(col.enabled == false) {
			if(waitTimer > 0) {
				waitTimer -= Time.deltaTime;
			} else {
				col.enabled = true;
			}
		}
	}
}
