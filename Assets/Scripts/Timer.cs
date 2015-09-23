using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	Text txtTimer;
	public string nextLevelName;
	string timeDisplay;
	public float timeLimit;

	// Use this for initialization
	void Start () 
	{
		txtTimer = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () 
	{

		timeLimit -= Time.deltaTime;

		int roundedSeconds = Mathf.CeilToInt(timeLimit);
		int minutes = roundedSeconds / 60;
		int seconds = roundedSeconds % 60;

		timeDisplay = string.Format("{0:00}:{1:00}",minutes,seconds);

		txtTimer.text = timeDisplay;
		if(minutes <=0 && seconds <= 0)
		{
			Application.LoadLevel(nextLevelName);
		}
	}
}
