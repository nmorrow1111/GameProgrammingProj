using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 2.0f;
    public float runSpeed = 6.0f;
    public float gravity = -12.0f;
    public float jumpHeight = 1.0f;

    [Range(0,1)]
    public float airControlPercent;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;
    float velocityY;

    Animator animator;
    Transform cameraT;

    CharacterController controller;

	// Use this for initialization
	IEnumerator Start ()
    {
        yield return new WaitForSeconds(.15f);

        animator = GetComponent<Animator>();
        cameraT = Camera.main.transform;
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Player Input
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;
        bool running = Input.GetKey(KeyCode.LeftShift);

        Move(inputDir, running);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // Player Animation
        float animationSpeedPercent = ((running) ? currentSpeed / runSpeed : currentSpeed / walkSpeed * .5f);
        animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);
    }
    // Player Movement
    void Move(Vector2 inputDir, bool running)
    {
        if (inputDir != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, getModifiedSmoothTime(turnSmoothTime));
        }

        float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, getModifiedSmoothTime(speedSmoothTime));

        velocityY += Time.deltaTime * gravity;

        Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;
        controller.Move(velocity * Time.deltaTime);
        currentSpeed = new Vector2(controller.velocity.x, controller.velocity.z).magnitude;

        if (controller.isGrounded)
        {
            velocityY = 0;
        }
    }
    // Player Jumping
    void Jump()
    {
        if(controller.isGrounded)
        {
            float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
            velocityY = jumpVelocity;
        }
    }
    // Required for smooth movements
    float getModifiedSmoothTime (float smoothTime)
    {
        if (controller.isGrounded)
        {
            return smoothTime;
        }

        if(airControlPercent == 0)
        {
            return float.MaxValue;
        }

        return smoothTime / airControlPercent;
    }
    // Checks for player Collision
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Collides with a chunk spawner (orb)
        if(hit.transform.tag == "SpawnChunk")
        {
            if (hit.gameObject.name == "SpawnChunkNorth")
            {
                Transform refChunk = hit.gameObject.GetComponentInParent<Transform>();
                hit.gameObject.GetComponentInParent<MapManager>().SpawnNewChunk("North", refChunk);
                Destroy(hit.gameObject);
            }

            else if (hit.gameObject.name == "SpawnChunkSouth")
            {
                Transform refChunk = hit.gameObject.GetComponentInParent<Transform>();
                hit.gameObject.GetComponentInParent<MapManager>().SpawnNewChunk("South", refChunk);
                Destroy(hit.gameObject);
            }

            else if (hit.gameObject.name == "SpawnChunkEast")
            {
                Transform refChunk = hit.gameObject.GetComponentInParent<Transform>();
                hit.gameObject.GetComponentInParent<MapManager>().SpawnNewChunk("East", refChunk);
                Destroy(hit.gameObject);
            }

            else if (hit.gameObject.name == "SpawnChunkWest")
            {
                Transform refChunk = hit.gameObject.GetComponentInParent<Transform>();
                hit.gameObject.GetComponentInParent<MapManager>().SpawnNewChunk("West", refChunk);
                Destroy(hit.gameObject);
            }
        }

        if (hit.transform.tag == "Enemy")
        {
            GetComponent<PlayerHealth>().DealDamage(5f);
            Debug.Log("Player hit.");
        }

        if (hit.transform.tag == "Chest")
        {
            float randomNum = Random.value;
            Debug.Log("ANYTHING?");
            GetComponent<PlayerMana>().ResetMana();
            /*
            if (randomNum < .50f)
            {
                Debug.Log("ANYTHING?");
                GetComponent<PlayerMana>().ResetMana();
            }
            */
            if (randomNum > .50f)
            {
                Debug.Log("ANYTHING?");
                GetComponent<PlayerHealth>().ResetHealth();
            }
            Destroy(hit.gameObject);
        }
    }
}
