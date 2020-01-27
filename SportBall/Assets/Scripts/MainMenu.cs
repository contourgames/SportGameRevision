using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public string playGameLevel;

	public void PlayGame()
	{
		Application.LoadLevel (playGameLevel);
        Ball.LeftScore = 0;
        Ball.RightScore = 0;
	}


	public void QuitGame()
	{
		Application.Quit ();
	}


}
