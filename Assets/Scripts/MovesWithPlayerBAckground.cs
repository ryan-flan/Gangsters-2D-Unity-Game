using UnityEngine;
using System.Collections;

public class MovesWithPlayerBAckground : MonoBehaviour 
{
	public float scrollSpeed;
	private Vector2 savedOffset;
	private Vector2 offset; 
	public GameObject player;
	private float counter = 0;
	// Use this for initialization

	void Start ()
	{
		savedOffset = renderer.sharedMaterial.GetTextureOffset ("_MainTex");
	}

	// Update is called once per frame
	void Update() 
	{
		float move = player.rigidbody2D.velocity.x;
		float x = Mathf.Repeat (counter * scrollSpeed, 1);
		offset.y = savedOffset.y;

		if (move > 0) 
		{
			counter += 0.01f;
			offset.x = x;
		}
		else if(move < 0) 
		{
			counter -= 0.01f;
			offset.x = x;
		}

		renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);

	}

	void OnDisable()
	{
		renderer.sharedMaterial.SetTextureOffset ("_MainTex", savedOffset);
	}
}
