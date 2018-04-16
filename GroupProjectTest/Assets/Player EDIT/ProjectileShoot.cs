using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public Rigidbody projectile;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        //If statment controlling the firing of the projectile from the game
        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody InstantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            InstantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        }
    }
}
