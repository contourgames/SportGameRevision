using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {

    public static int LeftScore = 0;
    public Text LeftscoreText;

    public static int RightScore = 0;
    public Text RightscoreText;

    //public AudioSource goalSound;
    //public AudioSource ballWall;

    //public ParticleSystem LeftGoal;
    //public ParticleSystem RightGoal;

    //public bool enteredGate = false;

    // Use this for initialization
    void Start () {

        //Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(Time.timeScale);

        LeftscoreText.text = "" + LeftScore;
       RightscoreText.text = "" + RightScore; 

        if(LeftScore == 5)
        {
            SceneManager.LoadScene("Player2Win");
        }

        if(RightScore == 5)
        {
            SceneManager.LoadScene("Player1Win");
        }
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "LeftGoal")
        {
            //GetComponent<CircleCollider2D>().enabled = false;
            LeftScore = LeftScore + 1;
            Invoke("SceneLoad", 0.5f);
            dParticlesLeft();
        }

        if (collision.gameObject.tag == "RightGoal")
        {
            //GetComponent<CircleCollider2D>().enabled = false;
            RightScore = RightScore + 1;
            Invoke("SceneLoad", 0.5f);
            dParticlesRight();
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("collide");
        if (collision.gameObject.tag == "Front Plat")
        {
        }
        if (collision.gameObject.tag == "OutOfBounds")
        {
            GetComponent<Transform>().position = new Vector2(0,0);
        }
        if (collision.gameObject.tag == "LeftGoal")
        {
            //GetComponent<CircleCollider2D>().enabled = false;
            LeftScore = LeftScore + 1;
            //Invoke("SceneLoad", 0.5f);
            dParticlesLeft();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "RightGoal")
        {
            //GetComponent<CircleCollider2D>().enabled = false;
            RightScore = RightScore + 1;
            //Invoke("SceneLoad", 0.5f);
            Destroy(gameObject);
            dParticlesRight();
        }
    }



    void OnCollisionExit2D(Collision2D collision)
    {
       
    }
 

    void SceneLoad()
    {
        SceneManager.LoadScene("Level");
    }

    void dParticlesLeft()
    {
        //LeftGoal.Play();
    }
    void dParticlesRight()
    {
       // RightGoal.Play();
    }

}
