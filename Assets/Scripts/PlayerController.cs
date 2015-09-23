using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour

{
	public float maxSpeed = 10f;
	public bool facingRight = true;
	public bool grounded = false;
	public bool flipped = false;
	public Transform groundCheck;
	public Transform flipCheck;
	public float groundRadius = 0.5f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;
	public float health;
	public AudioSource levelTheme;
	public bool isCar = false;
	Animator anim;
	public AudioClip deathSound;
	float deathCount = 0;
	float move;
	bool playerCanMove = true;
	HighScore currentScore;
	int deathScore;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
		currentScore = GameObject.Find("Camera").GetComponent<HighScore> ();
		levelTheme.Play ();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		float move = Input.GetAxis("Horizontal");

		if (isCar == false)
		{
				anim.SetBool ("Ground", grounded);
				anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);

			if (Input.GetAxis ("Vertical") < 0)
			{
				anim.SetBool ("isCrouching", true);
				move = move / 2;
			} 
			else 
			{
				anim.SetBool ("isCrouching", false);
			}

				} 
		else
		{
			flipped = Physics2D.OverlapCircle (flipCheck.position, groundRadius+3, whatIsGround);
			
			if (flipped == true) 
			{
				health -= 10;
			}

		}

		anim.SetFloat("Speed", Mathf.Abs(move));

		if (playerCanMove) 
		{
			rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		}

		anim.SetFloat ("Health",health);
		
		
		if (move > 0 && !facingRight)
		{
			Flip ();
		}
		else if (move < 0 && facingRight) 
		{
			Flip ();
		}

		if (health <= 0 && deathCount == 0)
		{
			deathCount = 1;
			StartCoroutine(Die());
		}

	}
	void Update()
	{
		if(grounded && Input.GetButtonDown("Jump") && playerCanMove && isCar == false)
		{
			anim.SetBool("Ground",false);
			rigidbody2D.AddForce(new Vector2 (0, jumpForce));
		}
		// Screen Shot with f12 key
		if (Input.GetKey("f12")) 
		{
			TakeScreenshot();
		}
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Application.Quit();
		}
	}
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "EnemyBullets" ||  coll.gameObject.tag == "Spear") 
		{
			Destroy (coll.gameObject);
			health -= 0.5f;
		}
		if (coll.gameObject.tag == "MeleeEnemy") 
		{
			health -= 0.5f;
		}
	}
	void TakeScreenshot()
	{
		// File path
		string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures).ToString() + "/Gangesters & Stuff/screenshots/"; 
		string fileName = "Screenshot";
		string monthVar = System.DateTime.Now.ToString("_MMyyyy_hhmmss");
		
		
		
		// Check if folder exists, if it doesn't, create it.
		if (!System.IO.Directory.Exists (folderPath)) 
		{
			System.IO.Directory.CreateDirectory (folderPath);
		}
		
		
		// Capture and store the screenshot
		Application.CaptureScreenshot(folderPath + fileName + monthVar + ".png");
	}
	
	IEnumerator Die()
	{
		//Saves the current score and level to be used in the "death scene"
		deathScore = currentScore.playerScore;
		PlayerPrefs.SetInt ("deathScore", deathScore);
		PlayerPrefs.SetInt ("currentLevel", Application.loadedLevel);
		
		playerCanMove = false;
		levelTheme.Pause();
		
		
		levelTheme.PlayOneShot(deathSound);
		yield return new WaitForSeconds (deathSound.length);
		
		// Restart the level when the music is finished.
		Application.LoadLevel("DeathScene");
	}
}
