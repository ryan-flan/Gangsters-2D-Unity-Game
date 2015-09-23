using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {


	public PlayerController playerScript;
	Animator healthSystem;
	
	// Use this for initialization
	void Start () 
	{
		healthSystem = GetComponent<Animator>();
		GameObject thePlayer = GameObject.Find("Player");
		thePlayer.GetComponent<PlayerController>();
	}
	// Update is called once per frame
	void FixedUpdate() 
	{
		healthSystem.SetFloat("Health", playerScript.health);
	}
}