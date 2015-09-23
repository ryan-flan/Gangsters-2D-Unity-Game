using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour {

	public int playerScore = 0;
	public int prevScore;
	// Used to change the appearance of the GUI
	public GUIStyle labelStyle;
	public int fontSize = 45;

	void Start()
	{
		prevScore = PlayerPrefs.GetInt("levelScore" + Application.loadedLevelName);
	}

	void Update()
	{

	}

	public void IncreaseScore(int amount)
	{
		playerScore += amount;
	}

	void OnGUI ()
	{
		// make the text bigger and white
		labelStyle.fontSize = fontSize;
		labelStyle.fontStyle = FontStyle.Bold;
		labelStyle.normal.textColor = Color.white;
		GUI.Label (new Rect (10, 10, 100, 30), "Score: " + playerScore.ToString(), labelStyle);


		GUI.Label (new Rect (10, 60, 100, 30), "Previous Score: " + prevScore.ToString(), labelStyle);
	}
}
