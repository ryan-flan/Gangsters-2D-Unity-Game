using UnityEngine;
using System.Collections;

public class OutlawHealth : MonoBehaviour {

	public float health = 3;
	Animator outlawAnim;
	HighScore scoreUpdate;

	// Use this for initialization
	void Start ()
	{
		outlawAnim = GetComponent<Animator>();
		scoreUpdate = GameObject.Find("Camera").GetComponent<HighScore> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		outlawAnim.SetFloat("Health",health);

	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		// This function is called when the bullets collide with the enemy gameobject.
		// It is used to deduct health from the enemy's float "health" and destroy the bullet objects when the
		// health is deducted.
		
		if (coll.gameObject.tag == "Bullets") 
		{
			Destroy(coll.gameObject);
			health -= 0.5f;
		}
		else if(coll.gameObject.tag == "PlayerMelee")
		{
			health-=1;
		}
		
		if (health == 0)
		{
			Die();
		}
	}
	void Die()
	{
		scoreUpdate.IncreaseScore (50);
		Destroy (gameObject,0.5f);
	}
}