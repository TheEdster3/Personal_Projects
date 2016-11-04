using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject player;
	private Vector3 camVector;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		camVector.x = player.transform.position.x;
		camVector.y = player.transform.position.y;
		camVector.z = -10;
		transform.position = camVector;

	}
}
