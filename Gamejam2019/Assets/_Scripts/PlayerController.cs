using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour {
	public float speed = 10.0f;

    Rigidbody2D rigidbody;
	float horizontal = 0.0f;
	float vertical = 0.0f;
	Vector3 vel = Vector3.zero;
	Animator animator;
	bool facingRight = true;
	Vector3 targetVelocity = Vector3.zero;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		animator.SetBool("isWalking", false);
	}
	
	// Update is called once per frame
	void Update () {
		horizontal = Input.GetAxisRaw("Horizontal");
		vertical = Input.GetAxisRaw("Vertical");
		targetVelocity = Vector3.zero;


	}

    private void FixedUpdate(){
		Move(horizontal, vertical);
		//updates animation based on input
		AnimUpdate(horizontal, vertical);
	}


	//changes the characters velocity depending on the input
	public void Move(float currentHorizontal, float currentVertical){


		////will set velocity in a direction to zero if no input
		if(vertical == 0) {
			Vector3 targetVelZero = rigidbody.velocity;
			targetVelZero = new Vector2(rigidbody.velocity.x, 0);
			rigidbody.velocity = targetVelZero;
		}

		if(horizontal == 0) {
			Vector3 targetVelZero = rigidbody.velocity;
			targetVelZero = new Vector2(0, rigidbody.velocity.y);
			rigidbody.velocity = targetVelZero;
		}

		//gets direction the player is walking
		if((currentHorizontal > 0 && !facingRight) || (currentHorizontal < 0 && facingRight)) {
			FlipSpriteHorizontal();
		}

		targetVelocity = new Vector2(currentHorizontal * speed, currentVertical * speed);
		//clamp velocity so diagonals aren't faster
		if(vertical != 0 && horizontal != 0) {
			//targetVelocity = 
		}

		rigidbody.velocity = Vector3.SmoothDamp(rigidbody.velocity, targetVelocity, ref vel, .05f);
	}

	//will flip the sprite in direction of horizontal movement
	public void FlipSpriteHorizontal(){
		facingRight = !facingRight;

		//flip sprite by multiplying by -1
		Vector3 localScale = transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}

	public void AnimUpdate(float currentHorizontal, float currentVertical)
	{
		//will set the animation to walking if any arrow key pressed - willl need to seperate out into vert and horizontal
		if(currentVertical == 0 && currentHorizontal == 0) {
			animator.SetBool("isWalking", false);
		} else {
			animator.SetBool("isWalking", true);
		}

		//sets the anim blend tree params
		animator.SetFloat("xInput", currentHorizontal);
		animator.SetFloat("yInput", currentVertical);
	}
}
