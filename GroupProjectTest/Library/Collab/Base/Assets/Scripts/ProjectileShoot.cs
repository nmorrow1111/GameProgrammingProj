﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour {

    public Rigidbody projectile;

    public Rigidbody fireball;
    public Rigidbody energyball;
    public Rigidbody iceball;

    public float speed;
    public Animator animator;
    public GameObject player;

    public void Start()
    {
        animator = GetComponentInParent<Animator>();
        projectile = fireball;
    }

    // Update is called once per frame
    public void Update()
    {
        if(Input.GetKeyUp(KeyCode.Alpha1))
        {
            projectile = fireball;
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            projectile = energyball;
        }

        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            projectile = iceball;
        }

        //If statment controlling the firing of the projectile from the game
        if (Input.GetMouseButtonDown(0) && animator.GetBool("Shoot") != true && !player.GetComponent<PlayerMana>().IsManaEmpty())
        {
            animator.SetTrigger("Shoot");
            StartCoroutine(TimeDelay());
            //Rigidbody InstantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            //InstantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        }
    }

    IEnumerator TimeDelay()
    {
        yield return new WaitForSeconds(1.0f);
        Rigidbody InstantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
        InstantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
    }
}
