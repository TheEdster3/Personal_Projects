using UnityEngine;
using System.Collections;

public class TimedStart : MonoBehaviour {

	public GameObject spawner_2;
	public float timeUntilActivation = 10.0F;
	public bool activated = false;
	// Use this for initialization
	void Start () {
		spawner_2.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		if (activated == false) 
		{
			timeUntilActivation -= Time.deltaTime;
			if (timeUntilActivation <= 0) {
				spawner_2.SetActive (true);
				spawner_2.GetComponent<ShotPatternStarter> ().levelMultiplayer = this.gameObject.GetComponent<ShotPatternStarter> ().levelMultiplayer;
				spawner_2.GetComponent<ShotPatternStarter>().timeBetweenShots = this.gameObject.GetComponent<ShotPatternStarter> ().startingTime;
				spawner_2.GetComponent<ShotPatternStarter>().multiplierFrequency = this.gameObject.GetComponent<ShotPatternStarter> ().startingFrequency;
				activated = true;
			}
		}
	}


}
