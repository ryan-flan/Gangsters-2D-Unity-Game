using UnityEngine;
using System.Collections;

public class MeleeAttacker : MonoBehaviour {

	public Transform target;
	public float speed = 3f;
	public float setRange;
	public bool facingRight;
	float range;
	Animator anim;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		range = Vector2.Distance (transform.position, target.position);
		float toTheRight = target.position.x - transform.position.x;

		if (range < setRange) 
		{
			
			if (toTheRight > 0 && !facingRight)
			{
				Flip ();
			}
			else if (toTheRight < 0 && facingRight) 
			{
				Flip ();
			}

			transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);

			anim.SetBool("Moving", true);
		} 
		else 
		{
			anim.SetBool("Moving",false);
		}
	}
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
}
