using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public int width = 45;
    public int height = 45;

    public GameObject player;
    public GameObject wall;
    public GameObject chunk;
    public GameObject zombie;
    public GameObject chest;
    private bool chestSpawned = false;
    private bool playerSpawned = false;
    private int MaxZombieCount;

    // Use this for initialization
    void Start()
    {
        // This is required for proper spawning, only took me 8 hours to get this to work...
        chunk = GameObject.Find("GM").GetComponent<GManager>().chunk;
        MaxZombieCount = GameObject.Find("GM").GetComponent<GManager>().zombieSpawnCounter;
        GenerateLevel();
    }

    // Loads the chunk with randomized walls and if the player is spawned or not will spawn the player.
    void GenerateLevel()
    {
        int CurrentZombiesSpawned = 0;

        if(GameObject.FindGameObjectWithTag("Player"))
        {
            playerSpawned = true;
        }

        for (int x = 0; x <= width; x += 3)
        {
            for (int y = 0; y <= height; y += 2)
            {
                if (Random.value > .75f)
                {
                    if(x > 20 && y > 20 && Random.value < .95f && !chestSpawned)
                    {
                        Vector3 pos = new Vector3(x - width / 2f, 1f, y - height / 2f) + transform.position;
                        Instantiate(chest, pos + new Vector3(0, 24, 0), Quaternion.identity, transform);
                        chestSpawned = true;
                    }
                    // Spawns Walls
                    else if (Random.value < .90f)
                    {
                        GameObject newWall;
                        Vector3 pos = new Vector3(x - width / 2f, 1f, y - height / 2f) + transform.position;
                        newWall = Instantiate(wall, pos + new Vector3(0, 25, 0), Quaternion.identity, transform);
                    }
                    // Spawns Zombies
                    else if(MaxZombieCount > CurrentZombiesSpawned)
                    {
                        Vector3 pos = new Vector3(x - width / 2f, 1.25f, y - height / 2f) + transform.position; ;
                        Instantiate(zombie, pos + new Vector3(0, 25, 0), Quaternion.identity, transform);
                        CurrentZombiesSpawned += 1;
                    }
                }
                // Spawns Player (Only once but randomly)
                else if (Random.value > .5f && !playerSpawned)
                {
                    Vector3 pos = new Vector3(x - width / 2f, 1.25f, y - height / 2f);
                    Instantiate(player, pos + new Vector3(0, 25, 0), Quaternion.identity);
                    playerSpawned = true;
                }
            }
        }

        GameObject.Find("GM").GetComponent<GManager>().AddZombieSpawnCounter();
    }
    // Spawns a new chunk while assuring nothing overlaps
    public void SpawnNewChunk(string direction, Transform refChunk)
    {
        Vector3 pos = refChunk.position;
        GameObject clone;

        if (direction == "North")
        {
            // Spawn the new randomized chunk here
            clone = Instantiate(chunk, pos + new Vector3(25.5f, -25f, 0f), Quaternion.identity);
            // Assign the name to the new chunk
            GameObject.Find("GM").GetComponent<GManager>().chunkCounter += 1;
            int chunkCounter = GameObject.Find("GM").GetComponent<GManager>().chunkCounter;
            clone.name = "NewChunk" + chunkCounter;
            //clone.GetComponent<MapManager>().chunk = chunk;
            // Remove the opposite invis wall and spawner to not cause overlapping
            GameObject removeThis = GameObject.Find("/" + clone.name + "/SpawnChunkSouth");
            if (removeThis)
            {
                Destroy(removeThis);
            }
        }

        else if (direction == "South")
        {
            // Spawn the new randomized chunk here
            clone = Instantiate(chunk, pos + new Vector3(-25.5f, -25f, 0f), Quaternion.identity);
            // Assign the name to the new chunk
            GameObject.Find("GM").GetComponent<GManager>().chunkCounter += 1;
            int chunkCounter = GameObject.Find("GM").GetComponent<GManager>().chunkCounter;
            clone.name = "NewChunk" + chunkCounter;
            //clone.GetComponent<MapManager>().chunk = chunk;
            // Remove the opposite invis wall and spawner to not cause overlapping
            GameObject removeThis = GameObject.Find("/" + clone.name + "/SpawnChunkNorth");
            if(removeThis)
            {
                Destroy(removeThis);
            }
        }

        else if (direction == "East")
        {
            // Spawn the new randomized chunk here
            clone = Instantiate(chunk, pos + new Vector3(0f, -25f, 25.5f), Quaternion.identity);
            // Assign the name to the new chunk
            GameObject.Find("GM").GetComponent<GManager>().chunkCounter += 1;
            int chunkCounter = GameObject.Find("GM").GetComponent<GManager>().chunkCounter;
            clone.name = "NewChunk" + chunkCounter;
            //clone.GetComponent<MapManager>().chunk = chunk;
            // Remove the opposite invis wall and spawner to not cause overlapping
            GameObject removeThis = GameObject.Find("/" + clone.name + "/SpawnChunkWest");
            if (removeThis)
            {
                Destroy(removeThis);
            }
        }

        else if (direction == "West")
        {
            // Spawn the new randomized chunk here
            clone = Instantiate(chunk, pos + new Vector3(0f, -25f, -25.5f), Quaternion.identity);
            // Assign the name to the new chunk
            GameObject.Find("GM").GetComponent<GManager>().chunkCounter += 1;
            int chunkCounter = GameObject.Find("GM").GetComponent<GManager>().chunkCounter;
            clone.name = "NewChunk" + chunkCounter;
            //clone.GetComponent<MapManager>().chunk = chunk;
            // Remove the opposite invis wall and spawner to not cause overlapping
            GameObject removeThis = GameObject.Find("/" + clone.name + "/SpawnChunkEast");
            if (removeThis)
            {
                Destroy(removeThis);
            }
        }
    }
}
