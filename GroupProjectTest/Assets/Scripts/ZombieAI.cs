using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class ZombieAI : MonoBehaviour {

    public NavMeshAgent zombie;
    public Transform player;
    Animator anim;
    CharacterController zombieController;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("PlayerUPDATED(Clone)").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        zombieController = GetComponent<CharacterController>();
    	}

    // Update is called once per frame
    void Update()
    {
        if(player)
        {
            zombie.SetDestination(player.position);
        }

        // Animation Control
        Vector3 horizontalVelocity = zombie.velocity;
        horizontalVelocity = new Vector3(zombie.velocity.x, 0, zombie.velocity.z);
        float horizontalSpeed = horizontalVelocity.magnitude / 8;

        if (horizontalSpeed > 0)
        {
            anim.SetFloat("speedPercent", 1, .1f, Time.deltaTime);
        }
        else
        {
            anim.SetFloat("speedPercent", 0, 0.1f, Time.deltaTime);
        }
    }
}
