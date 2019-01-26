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

	private void Start(){
		startWaitTime = waitTime;
		rigidbody = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate(){
		if(point >= PatrolPoints.Length) {
			point = 0;
		}


		transform.position = Vector2.MoveTowards(transform.position, PatrolPoints[point].position, speed * Time.deltaTime);
		if(Vector2.Distance(transform.position, PatrolPoints[point].position) < 0.3f) {
			if(waitTime <= 0) {
				point++;
				waitTime = startWaitTime;
			} else {
				waitTime -= Time.deltaTime;
			}

		}

	}

	private void OnCollisionEnter2D(Collision2D collision){
		rigidbody.velocity = Vector3.zero;
		hitPlayer = true;
	}

	private void OnCollisionExit2D(Collision2D collision){
		if(collision.gameObject.layer == 8) {
			hitPlayer = false;
		}
	}
}
