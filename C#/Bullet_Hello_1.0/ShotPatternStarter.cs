using UnityEngine;
using System.Collections;

public class ShotPatternStarter : MonoBehaviour {

	public float timeBetweenShots = 10.0f;
	public float levelMultiplayer = 1f;
	public float multiplierFrequency = 10f;

	public float startingTime = 0f;
	public float startingFrequency = 0f;

	private bool startLevel = true;
	private bool moveSpawner = true;
	private float tempFrequency;
	private float reloadTime;
	private Vector3[] screenPositions = new Vector3[9];
	private int randomInt = 0;
	// Use this for initialization
	void Start () {
		reloadTime = timeBetweenShots;
		tempFrequency = multiplierFrequency;

		startingTime = timeBetweenShots;
		startingFrequency = multiplierFrequency;

		loadArray ();

		transform.position = Camera.main.ViewportToWorldPoint (new Vector3 (0.00F, -1.0F, 1));

	}
	
	// Update is called once per frame
	void Update () {
		
		timeBetweenShots -= Time.deltaTime * levelMultiplayer;
		multiplierFrequency -= Time.deltaTime;

		if (startLevel && timeBetweenShots <= (startingTime - 3.0F))
		{
			StartCoroutine("MoveSpawner");
			timeBetweenShots *= .35f;
			startLevel = false;
		}
		if (timeBetweenShots <= 3F && moveSpawner) 
		{
			if (levelMultiplayer >= 2) {
				transform.position = screenPositions [4]; //Move to center

			} else {
				StartCoroutine("MoveSpawner");
			}
			moveSpawner = false;
		}
		if (timeBetweenShots <= 0F) 
		{
			timeBetweenShots = reloadTime;

			gameObject.GetComponent<UbhShotCtrl> ().StartShotRoutine ();
			gameObject.GetComponent<UbhShotCtrl> ().StopShotRoutine ();

			//Mark the spawner to be moved
			moveSpawner = true;
		}

		if (multiplierFrequency <= 0F) 
		{
			levelMultiplayer += .02f;
			multiplierFrequency = tempFrequency;
		}
		if (multiplierFrequency >= 2) {
		}
	}

	void loadArray()
	{
		screenPositions[0] = transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.05F,.93F,1)); //Left Top
		screenPositions[1] = transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.05F,0.5F,1)); //Left Middle
		screenPositions[2] = transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.05F,.05F,1)); //Left Bottom

		screenPositions[3] = transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5F,.93F,1)); //Middle Top
		screenPositions[4] = transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5F,.5F,1)); //Middle Center
		screenPositions[5] = transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5F,0.05F,1)); //Middle Bottom

		screenPositions[6] = transform.position = Camera.main.ViewportToWorldPoint(new Vector3(.95F, .93F,1)); //Right Top
		screenPositions[7] = transform.position = Camera.main.ViewportToWorldPoint(new Vector3(.95F,.5F,1)); //Right Middle
		screenPositions[8] = transform.position = Camera.main.ViewportToWorldPoint(new Vector3(.95F, .93F, 1)); //Right Bottom
	}

	IEnumerator MoveSpawner() {
		randomInt = Random.Range (0, 8);

		while (transform.position != screenPositions [randomInt] && levelMultiplayer != 2) {
			transform.position = Vector3.Lerp (transform.position, screenPositions [randomInt], Time.deltaTime);
			yield return null;
		}
	}
}
