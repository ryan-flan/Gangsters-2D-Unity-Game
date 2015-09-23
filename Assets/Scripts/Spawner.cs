using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject spawners;
	public int spawnRate;
 	int counter =1;

	// Update is called once per frame
	void Update () 
	{
		if (counter == spawnRate) 
		{
			GameObject clone;
			clone = (Instantiate (spawners, transform.position, transform.rotation)) as GameObject;
			clone.ToString();
			counter =0;
		}
		counter++;
	}
}
