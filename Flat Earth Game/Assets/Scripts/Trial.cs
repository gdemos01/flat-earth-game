using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trial : MonoBehaviour {

	// Old variables

	private float m_jumpTimeStamp = 0;
	private float m_minJumpInterval = 0.25f;
	private bool m_wasGrounded;


	// NEW
	Rigidbody rigidBody;
	Animator anim;
	CapsuleCollider capCol;
	[SerializeField] PhysicMaterial zFriction;
	[SerializeField] PhysicMaterial mFriction;
	Transform cam;

	[SerializeField] float speed = 0.8f;
	[SerializeField] float turnSpeed = 5;
	[SerializeField] float jumpPower = 10;

	Vector3 directionPos;
	Vector3 lookPos;
	Vector3 storeDir;

	float horizontal;
	float vertical;
	bool jumpInput;
	bool onGround;

	void Start(){
		rigidBody = GetComponent<Rigidbody> ();
		cam = Camera.main.transform;
		capCol = GetComponent<CapsuleCollider> ();
		SetupAnimator ();
		onGround = true;

		anim.SetBool("Grounded", onGround);
		anim.SetTrigger("Land");
		m_wasGrounded = onGround;
	}

	void Update(){
		HandleFriction ();
	}

	void HandleFriction(){
		if (horizontal == 0 && vertical == 0) {
			capCol.material = mFriction;
		} else {
			capCol.material = zFriction;
		}
	}


	void SetupAnimator(){
		anim = GetComponent<Animator> ();

		foreach (var childAnimator in GetComponentsInChildren<Animator>()) {
			if (childAnimator != anim) {
				anim.avatar = childAnimator.avatar;
				Destroy (childAnimator);
				break;
			}
		}
	}

	void FixedUpdate(){
		horizontal = Input.GetAxis ("Horizontal");
		vertical = Input.GetAxis ("Vertical");
		jumpInput = Input.GetButtonDown ("Jump");

		storeDir = cam.right;

		if (onGround) {
			rigidBody.AddForce (((storeDir * horizontal) + (cam.forward * vertical)) * speed / Time.deltaTime);

			if (jumpInput) {
				anim.SetTrigger ("Jump");
				rigidBody.AddForce (Vector3.up * jumpPower, ForceMode.Impulse);
			}
		}

		directionPos = transform.position + (storeDir * horizontal) + (cam.forward * vertical);

		Vector3 dir = directionPos - transform.position;
		dir.y = 0;

		// Don't know about these two
		float animValue = Mathf.Abs (vertical) + Mathf.Abs (horizontal);
		anim.SetFloat ("MoveSpeed", animValue, .1f, Time.deltaTime);

		if (horizontal !=0 || vertical !=0){

			float angle = Quaternion.Angle(transform.rotation,Quaternion.LookRotation(dir));

			if(angle!=0) // Look towards the camera
				rigidBody.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(dir),turnSpeed* Time.deltaTime);
			
		}
	}



}
