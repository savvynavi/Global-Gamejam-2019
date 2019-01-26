using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour {
	public float speed = 5.0f;
	public Transform[] PatrolPoints;
	public float waitTime = 2.0f;
	public float startWaitTime;

	Rigidbody2D rigidbody;
	int point = 0;
	bool hitPlayer = false;
	bool hitWall = false;

	private void Start(){
		startWaitTime = waitTime;
		rigidbody = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate(){
		if(point >= PatrolPoints.Length) {
			point = 0;
		}

		//if the enemy hasn't hit anything, it will patrol to the current point. ONce there, it will wait and then move to the next one
		if(hitPlayer != true && hitWall != true) {
			transform.position = Vector2.MoveTowards(transform.position, PatrolPoints[point].position, speed * Time.deltaTime);
			if(Vector2.Distance(transform.position, PatrolPoints[point].position) < 0.3f) {
				if(waitTime <= 0) {
					point++;
					waitTime = startWaitTime;
				} else {
					waitTime -= Time.deltaTime;
				}

			}
		} else {
			transform.position = transform.position;
			rigidbody.velocity = Vector3.zero;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision){
		rigidbody.velocity = Vector3.zero;
		hitWall = true;
		if(collision.gameObject.layer == 8) {
			hitPlayer = true;
			//put player death in here
		}
	}

	private void OnCollisionExit2D(Collision2D collision){
		hitWall = false;
		if(collision.gameObject.layer == 8) {
			hitPlayer = false;
		}
	}
}
