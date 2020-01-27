using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Controller : MonoBehaviour {

	public float Speed;
	public float JumpHeight = 5f;

	public float jumpTime;
	private float jumpTimeCounter;

	public Transform groundCheck;

	public float groundCheckRadius;

	public bool grounded;
	public LayerMask whatIsGround;
    public bool grounded2;
    public LayerMask whatIsGround2;

    private Rigidbody2D myRigidbody;

    public AudioSource jumpSound;
    public AudioSource BallHit;


    //Not public so we can't change it in the inspector
    float xSpeed = 0f;

	// Use this for initialization
	void Start()
	{
		jumpTimeCounter = jumpTime;

		myRigidbody = GetComponent<Rigidbody2D>();

	}



	// Update is called once per frame
	void Update()
	{

		myRigidbody.velocity = new Vector2(Speed, myRigidbody.velocity.y);

		if (Input.GetKeyDown("w"))
		{
            jumpSound.Play();

            if (grounded || grounded2)
			{
				myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, JumpHeight);
			}
		}
		if (Input.GetKey("w"))
		{
			if (jumpTimeCounter > 0)
			{

				myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, JumpHeight);
				jumpTimeCounter -= Time.deltaTime;
			}
		}
		if (Input.GetKeyUp("w"))
		{
			jumpTimeCounter = 0;
		}
		if (grounded || grounded2)
		{
			jumpTimeCounter = jumpTime;
		}

	}



	void FixedUpdate()
	{

		if (Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround) != null)
		{
			grounded = true;
		}
		else
		{
			grounded = false;
		}

        if (Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround2) != null)
        {
            grounded2 = true;
        }
        else
        {
            grounded2 = false;
        }


        if (Input.GetKey("d"))
		{
			xSpeed = Speed;
		}
		else if (Input.GetKey("a"))
		{
			xSpeed = -Speed;
		}
		else
		{
			xSpeed = 0;
		}
		//you're basically setting the speed of the jump which starts at 0f meaning it stays on the ground and up to 5f which is up in the air
		GetComponent<Rigidbody2D>().velocity = new Vector2(xSpeed, GetComponent<Rigidbody2D>().velocity.y);
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            BallHit.Play();
        }
        if (collision.gameObject.tag == "OutOfBounds")
        {
            GetComponent<Transform>().position = new Vector2(0, 0);
        }
    }
}


