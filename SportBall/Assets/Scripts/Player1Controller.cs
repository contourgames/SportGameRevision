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

    public float prepBlastVal;

    public int atkDir;
    public bool hasAtkd;


    //Not public so we can't change it in the inspector

	// Use this for initialization
	void Start()
	{
        PlayerPrefs.SetInt("LeftScore", 0);
        PlayerPrefs.SetInt("RightScore", 0);
		//jumpTimeCounter = jumpTime;

		myRigidbody = GetComponent<Rigidbody2D>();
        atkDir = 0;
	}



	// Update is called once per frame
	void Update()
	{

        #region Movement 1
        if (gameObject.tag == "Player1")
        {
            if (Input.GetKey("s") && hasAtkd == false)
            {
                if (prepBlastVal <= 15)
                {
                    prepBlastVal = prepBlastVal + 0.15f;
                }
            }
            else if (Input.GetKeyUp("s"))
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, myRigidbody.velocity.y + prepBlastVal);
                //prepBlastVal = 0;
                atkDir = 6;
            }

            if (Input.GetKey("a") && hasAtkd == false)
            {
                if (prepBlastVal <= 15)
                {
                    prepBlastVal = prepBlastVal + 0.15f;
                }
            }
            else if (Input.GetKeyUp("a"))
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x + prepBlastVal, myRigidbody.velocity.y + 0.5f);
                //prepBlastVal = 0;
                atkDir = 9;
            }

            if (Input.GetKey("d") && hasAtkd == false)
            {
                if (prepBlastVal <= 15)
                {
                    prepBlastVal = prepBlastVal + 0.15f;
                }
            }
            else if (Input.GetKeyUp("d"))
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x - prepBlastVal, myRigidbody.velocity.y + 0.5f);
                //prepBlastVal = 0;
                atkDir = 3;
            }

            if (Input.GetKey("w") && hasAtkd == false)
            {
                if (prepBlastVal <= 15)
                {
                    prepBlastVal = prepBlastVal + 0.15f;
                }
            }
            else if (Input.GetKeyUp("w"))
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, myRigidbody.velocity.y - prepBlastVal);
                //prepBlastVal = 0;
                atkDir = 12;
            }
        }
        #endregion

        #region Movement 2
        if (gameObject.tag == "Player2")
        {
            if (Input.GetKey(KeyCode.DownArrow) && hasAtkd == false)
            {
                if (prepBlastVal <= 15)
                {
                    prepBlastVal = prepBlastVal + 0.15f;
                }
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, myRigidbody.velocity.y + prepBlastVal);
                //prepBlastVal = 0;
                atkDir = 6;
            }

            if (Input.GetKey(KeyCode.LeftArrow) && hasAtkd == false)
            {
                if (prepBlastVal <= 15)
                {
                    prepBlastVal = prepBlastVal + 0.15f;
                }
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x + prepBlastVal, myRigidbody.velocity.y + 0.5f);
                //prepBlastVal = 0;
                atkDir = 9;
            }

            if (Input.GetKey(KeyCode.RightArrow) && hasAtkd == false)
            {
                if (prepBlastVal <= 15)
                {
                    prepBlastVal = prepBlastVal + 0.15f;
                }
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x - prepBlastVal, myRigidbody.velocity.y + 0.5f);
                //prepBlastVal = 0;
                atkDir = 3;
            }

            if (Input.GetKey(KeyCode.UpArrow) && hasAtkd == false)
            {
                if (prepBlastVal <= 15)
                {
                    prepBlastVal = prepBlastVal + 0.15f;
                }
            }
            else if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, myRigidbody.velocity.y - prepBlastVal);
                //prepBlastVal = 0;
                atkDir = 12;
            }
        }
        #endregion


        #region old code 
        //myRigidbody.velocity = new Vector2(Speed, myRigidbody.velocity.y);


        //if(Input.GetKey("space"))
        //{
        //    if (grounded)
        //    {
        //        jumpTimeCounter = jumpTime;
        //        jumpSound.Play();

        //    }
        //    if(jumpTimeCounter > 0)
        //    {
        //    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, JumpHeight);
        //    }
        //    jumpTimeCounter -= Time.deltaTime;
        //}



        //if (Input.GetKeyUp("space"))
        //{
        //    jumpTimeCounter = 0;
        //}

        //if (Input.GetKeyDown("space"))
        //      {
        //          if (grounded)
        //	{
        //		
        //              jumpSound.Play();
        //          }
        //}
        //if (Input.GetKey("space"))
        //{
        //	if (jumpTimeCounter > 0)
        //	{
        //		myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, JumpHeight);
        //		jumpTimeCounter -= Time.deltaTime;
        //	}
        //}
        //if (Input.GetKeyUp("space") && grounded)
        //{
        //	jumpTimeCounter = 0;
        //}
        //if (grounded)
        //{
        //	jumpTimeCounter = jumpTime;
        //          hasAtkd = false;
        //}

        #endregion


    }



    void FixedUpdate()
	{
        #region old code
        //if (Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround) != null)
        //{
        //	grounded = true;
        //}
        //else
        //{
        //	grounded = false;
        //}

        //if (Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround2) != null)
        //{
        //    grounded2 = true;
        //}
        //else
        //{
        //    grounded2 = false;
        //}



        //      if (Input.GetKey("d"))
        //{
        //	xSpeed = Speed;
        //}
        //else if (Input.GetKey("a"))
        //{
        //	xSpeed = -Speed;
        //}
        //else
        //{
        //	xSpeed = 0;
        //}
        //you're basically setting the speed of the jump which starts at 0f meaning it stays on the ground and up to 5f which is up in the air
        //GetComponent<Rigidbody2D>().velocity = new Vector2(xSpeed, GetComponent<Rigidbody2D>().velocity.y);

        #endregion
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


