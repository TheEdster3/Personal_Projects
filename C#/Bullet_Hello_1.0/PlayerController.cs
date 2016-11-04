using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour {
	public GameObject player;
	public float moveSpeed = 9.0F;
	public float acceleration = 0.0F;
	private Vector3 prevTargetPos;
	private Vector2 directionalVector;
	private Rigidbody2D myRB;
	// Use this for initialization

	void Start () {
		myRB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButton(0))
		{
			pointPlayerTowardsPoint(Input.mousePosition);
			accelerateTowardsPoint();
		}
		else if(Input.touchCount >= 2)
		{
			pointPlayerTowardsPoint (Input.GetTouch (0).position);
		}
		else if (acceleration != 0) {
			decelerate();
		}
		OnBecameInvisibile();
	}

	void pointPlayerTowardsPoint(Vector3 position)
	{
		//Rotate sprite towards mouse
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(position);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

		//Find position of the mouse for movement towards
		var targetPos = Camera.main.ScreenToWorldPoint (position);
		targetPos.z = transform.position.z;
		prevTargetPos = targetPos;
		directionalVector = (targetPos - transform.position).normalized;

	} //Do necessary math to point character towards mouse

	void accelerateTowardsPoint()
	{
		if (Vector3.Distance (prevTargetPos, transform.position) <= .2 && acceleration <= 3) {
			myRB.velocity = directionalVector * 0.0F;
		} 
		else if (Vector3.Distance (prevTargetPos, transform.position) <= .2) 
		{
			decelerate ();
		}
		else if (Vector3.Distance(prevTargetPos, transform.position) <= .5) 
		{
			decelerate ();
		}
		else if (acceleration < moveSpeed) {
			acceleration += .1F + (float)Math.Pow(.1d, 1.01d); //Make growth factor exponential for more realism
			myRB.velocity = directionalVector * acceleration;

			if (acceleration > moveSpeed)
				acceleration = moveSpeed;
			
		} //Accelerate until we reach max movespeed
		else {
			myRB.velocity = directionalVector * moveSpeed;
		}
	}

	void decelerate()
	{
		if (acceleration > 0) {
			myRB.velocity = directionalVector * acceleration;

			acceleration -= (.27F + (float)Math.Pow(.12d, 1.01d));

			if (acceleration < 0) {
				acceleration = 0;
				myRB.velocity = directionalVector * 0.0F;
			}
		}
	}

	void OnBecameInvisibile()
	{
		var cam = Camera.main;
		var viewportPosition = cam.WorldToViewportPoint(transform.position);
		var newPosition = transform.position;

		if (viewportPosition.x > 1 || viewportPosition.x < 0)
		{
			newPosition.x = -newPosition.x;
		}

		if (viewportPosition.y > 1 || viewportPosition.y < 0)
		{
			newPosition.y = -newPosition.y;
		}

		transform.position = newPosition;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Projectile") 
		{
			other.gameObject.SetActive (false);
			gameObject.SetActive (false);
			SceneManager.LoadScene("gameOver");
		}
	}

}
