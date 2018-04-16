using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    // Saving chunk prefab for correct spawning
    public GameObject chunk;
    // For chunk name varience
    public int chunkCounter;

    // Use this for initialization
    void Awake ()
    {
        chunkCounter = 0;
        // Other Game Mechanics Stored Here
	}
	
}
