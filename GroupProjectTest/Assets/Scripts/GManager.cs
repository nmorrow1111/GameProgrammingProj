using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    // Saving chunk prefab for correct spawning
    public GameObject chunk;
    // For chunk name varience
    public int chunkCounter;
    public int zombieSpawnCounter;
    public string finalScore;

    // Use this for initialization
    void Awake ()
    {
        Time.timeScale = 1;
        chunkCounter = 0;
        zombieSpawnCounter = 5;
        // Other Game Mechanics Stored Here
	}

    void Update()
    {
        if (GameObject.Find("PlayerUPDATED(Clone)"))
        {
            finalScore = GameObject.Find("PlayerUPDATED(Clone)").GetComponent<Score>().score.text;
        }
    }

    public void AddZombieSpawnCounter()
    {
        zombieSpawnCounter += 1;
    }
	
}
