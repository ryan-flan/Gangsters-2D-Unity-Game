using UnityEngine;
using System.Collections;

public class FallWhenCollide : MonoBehaviour {

	public bool isSpaceBullet =false;


	AudioSource bulletDing;
	// Use this for initialization
	void Start () 
	{
		bulletDing = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag != "Player" && coll.gameObject.tag != "Enemy")
		{
			if (coll.gameObject.tag == "Bullets" || coll.gameObject.tag == "EnemyBullets")
			{
				bulletDing.Play ();
			}
			if(isSpaceBullet==false)
			{
				rigidbody2D.gravityScale = 1;
			}
		}

	}
}
