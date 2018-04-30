using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public int CurrentScore { get; set; }
    public string scoreVal;
    public Text score;
  

    void Start () {
        CurrentScore = 0;
        scoreVal = "";
	}

    void Update()
    {
        scoreVal = CurrentScore.ToString();
        score.text = "Score: " + scoreVal;
    }

    public void AddScore()
    {
        CurrentScore += 1;
    }

    public void displayScore()
    {
        score.text = "Score: " + scoreVal;
    }

    /*
    void OnCollisionEnter(Collision other)
    {
        int number = 0;
        // Fix this for proper damage control here
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log ("FUCK!!!");
            number++;
            score.text = "Score: " + number;

        }
    }
    // Update is called once per frame
    */
    
}
