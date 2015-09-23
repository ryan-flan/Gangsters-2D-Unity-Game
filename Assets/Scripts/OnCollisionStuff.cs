using UnityEngine;
using System.Collections;

public class OnCollisionStuff : MonoBehaviour {

	// Use this for initialization
	public string nextLevelName;
	public bool endsLevel = false;
	public bool resetsLevel = false;
	public bool canKill = false;
	public bool isCollidingKill = false;
	public int levelScore;
	HighScore score;

	void OnCollisionEnter2D(Collision2D coll)
	{ 
		score = GameObject.Find ("Camera").GetComponent<HighScore> ();
		isCollidingKill = true;
		if (canKill)
		{	
			if(coll.gameObject.GetComponent<OutlawHealth>() != null)
			{
				OutlawHealth health = coll.gameObject.GetComponent<OutlawHealth>();
				health.health= 0;
			}
			else if(coll.gameObject.GetComponent<PlayerController>() != null)
			{
				PlayerController player = coll.gameObject.GetComponent<PlayerController>();
				player.health =0;
			}
		}
		if (coll.gameObject.tag == "Player" || coll.gameObject.tag=="PlayerMelee") 
		{

			int prevLevelScore = PlayerPrefs.GetInt("levelScore" + Application.loadedLevelName);
			levelScore = score.playerScore;

			if(endsLevel)
			{
				if(levelScore> prevLevelScore)
				{
					PlayerPrefs.SetInt("levelScore" + Application.loadedLevelName, levelScore);
				}

				Application.LoadLevel(nextLevelName);
			}
			if(resetsLevel)
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}

	}
}
