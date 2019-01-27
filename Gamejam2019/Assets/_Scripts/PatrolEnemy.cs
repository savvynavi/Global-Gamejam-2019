using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour {
	public float speed = 5.0f;
	public Transform[] PatrolPoints;
	public float waitTime = 2.0f;
	public float startWaitTime;

	Animator anim;
	Rigidbody2D rigidbody;
	int point = 0;
	bool hitPlayer = false;
	bool hitWall = false;
	Death death;

	Transform currentPos;
	Transform prevPos;
	bool facingRight = true;

	private void Start(){
		startWaitTime = waitTime;
		rigidbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		anim.SetBool("isWalking", false);
		death = GameObject.FindGameObjectWithTag("Loader").GetComponent<Death>();
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

		if(point == 0) {
			UpdateAnimation(PatrolPoints[point]);
		} else {
			UpdateAnimation(PatrolPoints[point - 1]);
		}


	}

	public void FlipSpriteHorizontal(){
		facingRight = !facingRight;

		//flip sprite by multiplying by -1
		Vector3 localScale = transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}


	void UpdateAnimation(Transform point){
		Vector3 heading = point.position - transform.position;
		var dist = heading.magnitude;

		Vector3 dir = heading / dist;


		//gets direction the player is walking
		if((dir.x > 0 && !facingRight) || (dir.y < 0 && facingRight)) {
			FlipSpriteHorizontal();
		}


		if(dir.x == 0 && dir.y == 0) {
			anim.SetBool("isWalking", false);
		} else {
			anim.SetBool("isWalking", true);
		}

		if(dir.x > 0) {
			anim.SetFloat("xInput", 1.0f);
		}

		if(dir.x < 0) {
			anim.SetFloat("xInput", -1.0f);
		}

		if(dir.y > 0) {
			anim.SetFloat("yInput", 1.0f);
		}

		if(dir.y < 0) {
			anim.SetFloat("yInput", -1.0f);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision){
		rigidbody.velocity = Vector3.zero;
		hitWall = true;
		if(collision.gameObject.layer == 8) {
			hitPlayer = true;
			//put player death in here

			//turn off player controls so they can't move, then fade in death screen
			collision.gameObject.GetComponent<PlayerController>().enabled = false;
			death.LoadDeathScene();
		}
	}

	private void OnCollisionExit2D(Collision2D collision){
		hitWall = false;
		if(collision.gameObject.layer == 8) {
			hitPlayer = false;
		}
	}
}
