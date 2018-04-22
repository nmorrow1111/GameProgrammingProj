using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour {

    public Rigidbody projectile;
    public float speed;
    Animator animator;

    public void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        //If statment controlling the firing of the projectile from the game
        if (Input.GetMouseButtonDown(0) && animator.GetBool("Shoot") != true)
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
