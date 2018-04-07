using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{

    public int width = 100;
    public int height = 100;

    public GameObject player;
    public GameObject wall;

    private bool playerSpawned = false;

    // Use this for initialization
    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        for (int x = 0; x <= width; x += 3)
        {
            for (int y = 0; y <= height; y += 2)
            {
                if (Random.value > .7f)
                {
                    Vector3 pos = new Vector3(x - width / 2f, 1f, y - height / 2f);
                    Instantiate(wall, pos + new Vector3(0,25,0), Quaternion.identity, transform);
                }
                else if (!playerSpawned)
                {
                    Vector3 pos = new Vector3(x - width / 2f, 1.25f, y - height / 2f);
                    Instantiate(player, pos + new Vector3(0, 25, 0), Quaternion.identity);
                    playerSpawned = true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
