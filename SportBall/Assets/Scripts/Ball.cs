using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {

    public bool inBounds = false;
    Vector2 origin;
    float ease;

    //public AudioSource goalSound;
    //public AudioSource ballWall;

    //public ParticleSystem LeftGoal;
    //public ParticleSystem RightGoal;

    //public bool enteredGate = false;

    // Use this for initialization
    void Start () {
        ease = Random.Range(0.005f, 0.15f);
        origin = new Vector2(0, 0);
        //Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {

        if(inBounds == false)
        {
            Vector2 SmoothPos = Vector2.Lerp(transform.position, origin, Time.deltaTime * 0.1f);
            transform.position = new Vector3(SmoothPos.x, SmoothPos.y, transform.position.z);
            GetComponent<CircleCollider2D>().enabled = false;
        } else
        {
            GetComponent<CircleCollider2D>().enabled = true;

        }

        if(transform.position.x <= 10 && transform.position.x >= -10 && transform.position.y <= 5 && transform.position.y >= -5)
        {
            inBounds = true;
        }

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }


        //Debug.Log(Time.timeScale);

       // LeftscoreText.text = "" + LeftScore;
       //RightscoreText.text = "" + RightScore; 

       // if(LeftScore == 5)
       // {
       //     SceneManager.LoadScene("Player2Win");
       // }

       // if(RightScore == 5)
       // {
       //     SceneManager.LoadScene("Player1Win");
       // }
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.gameObject.tag == "LeftGoal")
        //{
        //    //GetComponent<CircleCollider2D>().enabled = false;
        //    LeftScore = LeftScore + 1;
        //    Invoke("SceneLoad", 0.5f);
        //    dParticlesLeft();
        //}

        //if (collision.gameObject.tag == "RightGoal")
        //{
        //    //GetComponent<CircleCollider2D>().enabled = false;
        //    RightScore = RightScore + 1;
        //    Invoke("SceneLoad", 0.5f);
        //    dParticlesRight();
        //}

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        //inBounds = true;
        ////Debug.Log("collide");
        //if (collision.gameObject.tag == "Front Plat")
        //{
        //}
        //if (collision.gameObject.tag == "OutOfBounds")
        //{
        //    GetComponent<Transform>().position = new Vector2(0,0);
        //}
        if (collision.gameObject.tag == "LeftGoal")
        {
            //GetComponent<CircleCollider2D>().enabled = false;
            PlayerPrefs.SetInt("RightScore", PlayerPrefs.GetInt("RightScore") + 1);
            //Invoke("SceneLoad", 0.5f);

            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "RightGoal")
        {
            //GetComponent<CircleCollider2D>().enabled = false;
            PlayerPrefs.SetInt("LeftScore", PlayerPrefs.GetInt("LeftScore") + 1);

            //Invoke("SceneLoad", 0.5f);
            Destroy(gameObject);

        }
    }



    void OnCollisionExit2D(Collision2D collision)
    {
       
    }
 

    void SceneLoad()
    {
        //SceneManager.LoadScene("Level");
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
