using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// What do I need to add here to make the UI text work?

public class BallColl : MonoBehaviour {

	//What does making this variable static do?

	public Text redScore;
	int myGoals = 0;

	void Update() {

	}

	//What does this do?
	//when the ball hits the goal the goal counter goes up by one and the ball is destroyed
	void OnCollisionEnter2D(Collision2D other) {
		Debug.Log("you scored a Goal!");
		myGoals++;
		redScore.text = "Goals: " + myGoals;
		Destroy(other.gameObject);
	}
}