using UnityEngine;
using System.Collections;

public class SimpleFollow : MonoBehaviour 
{
	public Transform target;
	public float smooth = 0.5f;
	public float xOffset;
	public float yOffset;
	public float yMove;
	public float jumpPos;
	Vector3 lowPos;
	Vector3 highPos;
	bool isMoving = false;
	bool isHigh = true;
	float ogY;
	float ogZ;
	float x;
	float y;
	public float counter = 0;
	
	void Start () 
	{
		ogY = transform.position.y;
		ogZ = transform.position.z;
	}
	void Update ()
	{  
		y = target.position.y;
		x = target.position.x;
		lowPos.Set(x + xOffset, ogY+ yOffset, ogZ);
		highPos.Set (x + xOffset, jumpPos, ogZ);

		if (y > yMove) 
		{
			StartCoroutine(goHigh());
		} 
		else if (y < yMove && isHigh) 
		{
			StartCoroutine(goLow());
		} 
		else
		{
			goDefault();
		}

		counter += 0.05f;
		if (counter > 1 && (isMoving == false || isHigh == false)) 
		{
			counter = 0;
		}
	}
	IEnumerator goHigh()
	{
		isHigh = true;
		transform.position = Vector3.Lerp(lowPos, highPos, counter * smooth);
		isMoving = true;
		yield return new WaitForSeconds(0.5f);
		isMoving = false;

	}
	 IEnumerator goLow()
	{
		transform.position = Vector3.Lerp(highPos,lowPos,counter * smooth);
		isMoving = true;
		yield return new WaitForSeconds(1);
		isMoving = false;
		isHigh = false; 
	}
	void goDefault()
	{
		transform.position = new Vector3 (x + xOffset , lowPos.y + yOffset, lowPos.z);
		isHigh = false;
		isMoving = false;
	}
}