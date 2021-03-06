using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float MaxSpeed = 1f;
	public float JumpSpeed = 5f;

	//Not public so we can't change it in the inspector
	float xSpeed = 0f;

	// Use this for initialization
	void Start () {

	}


	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.RightArrow)) {
			xSpeed += MaxSpeed;
		} else if (Input.GetKeyUp (KeyCode.RightArrow)) {
			xSpeed = 0f;
		}
			

		if (Input.GetKey (KeyCode.LeftArrow)) {
			xSpeed -= MaxSpeed;
		} else if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			xSpeed = 0f;
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			xSpeed = 0f;
		}
		//you're basically setting the speed of the jump which starts at 0f meaning it stays on the ground and up to 5f which is up in the air
		GetComponent<Rigidbody2D>().velocity = new Vector2 (xSpeed, GetComponent<Rigidbody2D>().velocity.y);

		if (Input.GetKeyDown(KeyCode.UpArrow)) {

			GetComponent<Rigidbody2D>().velocity += new Vector2 (0f, JumpSpeed);
		}
	}
}
