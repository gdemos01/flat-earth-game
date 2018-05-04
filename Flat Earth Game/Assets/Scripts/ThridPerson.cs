using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThridPerson : MonoBehaviour {

	private float m_jumpTimeStamp = 0;
	private float m_minJumpInterval = 0.25f;
	private bool m_wasGrounded;
	private List<Collider> m_collisions = new List<Collider>();

	Rigidbody rigidBody;
	Animator anim;
	CapsuleCollider capCol;
	[SerializeField] PhysicMaterial zFriction;
	[SerializeField] PhysicMaterial mFriction;
	Transform cam;

	[SerializeField] float speed = 0.8f;
	[SerializeField] float turnSpeed = 5;
	[SerializeField] float jumpPower = 5;

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


	void HandleFriction(){
		if (horizontal == 0 && vertical == 0) {
			capCol.material = mFriction;
		} else {
			capCol.material = zFriction;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		ContactPoint[] contactPoints = collision.contacts;
		for(int i = 0; i < contactPoints.Length; i++)
		{
			if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
			{
				if (!m_collisions.Contains(collision.collider)) {
					m_collisions.Add(collision.collider);
				}
				onGround = true;
				rigidBody.drag = 5;
			}
		}
	}

	private void OnCollisionStay(Collision collision)
	{
		ContactPoint[] contactPoints = collision.contacts;
		bool validSurfaceNormal = false;
		for (int i = 0; i < contactPoints.Length; i++)
		{
			if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
			{
				validSurfaceNormal = true; break;
			}
		}

		if(validSurfaceNormal)
		{
			onGround = true;
			if (!m_collisions.Contains(collision.collider))
			{
				m_collisions.Add(collision.collider);
			}
		} else
		{
			if (m_collisions.Contains(collision.collider))
			{
				m_collisions.Remove(collision.collider);
			}
			if (m_collisions.Count == 0) { 
				onGround = false;
				rigidBody.drag = 0;
			}
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if(m_collisions.Contains(collision.collider))
		{
			m_collisions.Remove(collision.collider);
		}
		if (m_collisions.Count == 0) { 
			onGround = false;
			rigidBody.drag = 0;
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

	void Update(){
		HandleFriction ();

		anim.SetBool("Grounded", onGround);


		if (!m_wasGrounded && onGround)
		{
			anim.SetTrigger("Land");
		}

		m_wasGrounded = onGround;

		if (Input.GetKeyDown (KeyCode.Space) && onGround) {
			anim.SetTrigger ("Jump");
			rigidBody.AddForce (Vector3.up * jumpPower, ForceMode.Impulse);
		}
	}

	void FixedUpdate(){
		horizontal = Input.GetAxis ("Horizontal");
		vertical = Input.GetAxis ("Vertical");

		storeDir = cam.right;

		if (onGround) {
			rigidBody.AddForce (((storeDir * horizontal) + (cam.forward * vertical)) * speed / Time.deltaTime);
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
