using UnityEngine;
using System.Collections;

public class ProjectileDespawner : MonoBehaviour {

	private Rigidbody2D myRB;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		setInactive ();
	}

	void setInactive()
	{
	
	}

	void OnCollisionEnter2D(Collision2D objectYouCollidedWith) 
	{ 
		if (objectYouCollidedWith.gameObject.tag == "Projectile") 
		{
			objectYouCollidedWith.gameObject.SetActive (false);
		}
	}
}
