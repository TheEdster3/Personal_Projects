using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	// Use this for initialization

	private int score = 0;
	private int counter = 0;
	private int counterMultiplier = 1;
	private float counterGrowthFactor = 1F;
	private float timeToAddPoints = .5F;

	void Start () {
		this.GetComponent<Text> ().text = 0.ToString();
	}
	
	// Update is called once per frame
	void Update () {

		timeToAddPoints -= Time.deltaTime;
		if (timeToAddPoints <= 0)
		{
			timeToAddPoints = .5F;
			counter++;
			if (counter % 60 == 0) {
				counterMultiplier += 1;
				counterGrowthFactor += 0.1F;
			}
			else
				score += (int)(counterMultiplier * counterGrowthFactor);
			
			this.GetComponent<Text> ().text = score.ToString();
		} //Properly adjust score with time
	}
}
