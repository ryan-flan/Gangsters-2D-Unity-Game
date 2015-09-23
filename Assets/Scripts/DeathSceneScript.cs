using UnityEngine;
using System.Collections;

public class DeathSceneScript : MonoBehaviour {

	int score = 0;
	int prevLevel = 0;
	string filePath;
	public GUIStyle labelStyle;

	// Use this for initialization
	void Start () 
	{
		score = PlayerPrefs.GetInt ("deathScore");
		prevLevel = PlayerPrefs.GetInt ("currentLevel");

	}
	

	void OnGUI()
	{
		labelStyle.fontSize = 20;
		labelStyle.fontStyle = FontStyle.Bold;
		labelStyle.normal.textColor = Color.black;

		labelStyle.alignment = TextAnchor.MiddleCenter;

		GUI.Label (new Rect (Screen.width / 2 - 40, 350, 80, 30), "GAME OVER", labelStyle);

		GUI.Label (new Rect(Screen.width / 2 - 40, 400, 80, 40), "Your Score Was: " + score, labelStyle);

		if (GUI.Button (new Rect (Screen.width / 2 - 30, 500, 100, 30), "Retry Level"))
		{
			Application.LoadLevel(prevLevel);
		}
		if (GUI.Button (new Rect (Screen.width / 2 - 30, 450, 100, 30), "Main Menu"))
		{
			Application.LoadLevel("MainMenu");
		}
	}
	

}
