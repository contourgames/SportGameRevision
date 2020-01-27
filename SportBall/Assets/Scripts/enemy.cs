using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
	public GameObject TB; 
	public GameObject BB;
	Rigidbody2D rig; 
	bool dir; 
	//want to make bool false when you start and then in update get the location of lb and rb and change dir if this.gameobject
	//equals lb by changing velocity to the negative of what it was.
	// Use this for initialization
	void Start () {
		dir = false; 
		rig = GetComponent < Rigidbody2D > (); 
	}
	
	// Update is called once per frame
	void Update () {
		if (TB.transform.position.y >= transform.position.y) {
			dir = true;
		} 
		if (BB.transform.position.y <= transform.position.y) {
			dir = false;
		} 
		if (dir) {
			rig.velocity = new Vector2 (0, 4f); 
		}
		if (!dir) { 
			rig.velocity = new Vector2 (0, -4f);
		}
	}

}
