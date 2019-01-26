using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class EnemyController : MonoBehaviour {
	//remove after testing
	//public GameObject player;
	public float speed = 5.0f;

	bool hitPlayer = false;
	Rigidbody2D rigidbody;
	Vector3 vel = Vector3.zero;
	Animator anim;
	Vector3 targetVelocity = Vector3.zero;
	Ray ray;
	LayerMask mask = 1 << 10;


	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		targetVelocity = Vector3.zero;
	}

	private void FixedUpdate(){
		AnimUpdate();
		if(hitPlayer != true) {
			//shoots raycast in all directions, if hit player will move
			RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up, 100.0f, ~mask);
			if(hitUp && hitUp.collider.gameObject.layer == 8) {
				Move(hitUp);
			}

			RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, 100.0f, ~mask);
			if(hitRight && hitRight.collider.gameObject.layer == 8) {
				Move(hitRight);
			}

			RaycastHit2D hitDown = Physics2D.Raycast(transform.position, Vector2.down, 100.0f, ~mask);
			if(hitDown && hitDown.collider.gameObject.layer == 8) {
				Move(hitDown);
			}

			RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, 100.0f, ~mask);
			if(hitLeft && hitLeft.collider.gameObject.layer == 8) {
				Move(hitLeft);
			}
		}
		
	}

	//when the player has been detected, the enemy will move in a straight line towards where it saw them
	void Move(RaycastHit2D hit){
		targetVelocity = new Vector2((transform.position.x - hit.point.x) * speed, (transform.position.y - hit.point.y) * speed).normalized * speed;
		rigidbody.velocity = Vector3.SmoothDamp(rigidbody.velocity, -targetVelocity, ref vel, .05f);
	}

	void FlipSprite(){

	}

	void AnimUpdate(){

	}

	private void OnCollisionEnter2D(Collision2D collision){
		rigidbody.velocity = Vector3.zero;
		hitPlayer = true;
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if(collision.gameObject.layer == 8) {
			hitPlayer = false;
		}
	}
}
