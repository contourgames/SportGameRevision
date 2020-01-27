﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {

    public static int LeftScore = 0;
    public Text LeftscoreText;

    public static int RightScore = 0;
    public Text RightscoreText;

    public AudioSource goalSound;
    public AudioSource ballWall;

    public ParticleSystem LeftGoal;
    public ParticleSystem RightGoal;

    // Use this for initialization
    void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
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
            goalSound.Play();
            GetComponent<CircleCollider2D>().enabled = false;
            LeftScore = LeftScore + 1;
            Invoke("SceneLoad", 0.5f);
            dParticlesLeft();
        }

        if (collision.gameObject.tag == "RightGoal")
        {
            goalSound.Play();
            GetComponent<CircleCollider2D>().enabled = false;
            RightScore = RightScore + 1;
            Invoke("SceneLoad", 0.5f);
            dParticlesRight();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Front Plat")
        {
            ballWall.Play();
        }
        if (collision.gameObject.tag == "OutOfBounds")
        {
            GetComponent<Transform>().position = new Vector2(0,0);
        }
    }
 

    void SceneLoad()
    {
        SceneManager.LoadScene("Level");
    }

    void dParticlesLeft()
    {
        LeftGoal.Play();
    }
    void dParticlesRight()
    {
        RightGoal.Play();
    }

}
