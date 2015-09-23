using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {

	public GameObject bullet;
	public float bulletLifeTime = 120;
	public bool onlyShootWhenInRange;
	public Transform target;
	public float setRange;
	public float firepower = 1000;
	float range;
	float counter = 0;
	public float rateOfFire;
	AudioSource gunshot;

	// Use this for initialization
	void Start () 
	{
		gunshot = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		counter++;

		if (counter == rateOfFire) 
		{
			if (onlyShootWhenInRange == false)
			{
				shoot ();
			}
			else
			{
				checkIfInRange();
			}

			counter = 0;
		}
	}
	void checkIfInRange()
	{
		range = Vector2.Distance (transform.position, target.position);
		if (range < setRange)
		{
			shoot ();
		}
	}
	public void shoot()
	{
		
		GameObject clone;
		clone = (Instantiate(bullet, transform.position,transform.rotation)) as GameObject;

		if(clone.gameObject.tag == "Spear")
		{
			clone.transform.Rotate(0,0,90);
		}
		gunshot.Play ();

		Destroy (clone, bulletLifeTime);

		clone.rigidbody2D.AddForce (new Vector2 (-firepower, 0));

		
	}
}
