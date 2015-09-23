using UnityEngine;
using System.Collections;

public class FiringScript : MonoBehaviour
{
	public GameObject bullet;
	public float bulletLifetime = 3;
	public bool facingRight;
	AudioSource gunshot;

	// Use this for initialization
	void Start () 
	{
		gunshot = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		float move = Input.GetAxis ("Horizontal");
		if (move > 0) 
		{
			facingRight = true;
		} 
		else if (move < 0)
		{
			facingRight = false;
		}

		if(Input.GetButtonDown("Fire1")) 
		{
			shoot ();
		}
	}

	public void shoot()
	{

		GameObject clone;
		clone = (Instantiate(bullet, transform.position,transform.rotation)) as GameObject;
		gunshot.Play ();

		Destroy (clone, bulletLifetime);

		if (facingRight) 
		{
			clone.rigidbody2D.AddForce (new Vector2 (1000, 0));
		} 
		else 
		{
			clone.transform.Rotate( new Vector3 (0,180,0));
			clone.rigidbody2D.AddForce (new Vector2 (-1000, 0));
		}

	}
}
