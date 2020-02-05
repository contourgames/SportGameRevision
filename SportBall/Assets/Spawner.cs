using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{

    public GameObject asteroidPref;

    public Text LeftText;
    public Text RightText;

    public Text winText;
    int leftScore;
    int rightScore;
    // Start is called before the first frame update
    void Start()
    {
        winText.gameObject.SetActive(false);
        InvokeRepeating("spawnAsteroid", 0, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        RightText.text = "" + PlayerPrefs.GetInt("RightScore");
        LeftText.text = "" + PlayerPrefs.GetInt("LeftScore");

        if(PlayerPrefs.GetInt("RightScore") >= 10)
        {
            winText.text = "USSR Wins!";
        winText.gameObject.SetActive(true);
        }else
            if (PlayerPrefs.GetInt("LeftScore") >= 10)
        {
            winText.text = "USA Wins!";
            winText.gameObject.SetActive(true);
        }
    }

    void spawnAsteroid()
    {
        if (PlayerPrefs.GetInt("RightScore") < 10 && (PlayerPrefs.GetInt("LeftScore") < 10))
        {
            GameObject Asteroid = Instantiate(asteroidPref);
            Asteroid.transform.position = new Vector2((transform.position.x + Random.Range(-30, 30)), transform.position.y);
        }
    }

    // spawn outside screen. when enters screen bounds, turn collider on to keep it on the screen
}
