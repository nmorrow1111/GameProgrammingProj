using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroyUponContact : MonoBehaviour {

    public GameObject iceSlow;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("SpawnChunk"))
        {
            Destroy(this.gameObject);
        }
        // Fix this for proper damage control here
        if(other.gameObject.CompareTag("Enemy"))
        {
            if(gameObject.name == "FireBall(Clone)")
            {
                // Do Stuff
                Destroy(this.gameObject);
                Destroy(other.gameObject);
            }

            else if (gameObject.name == "EnergyBall(Clone)")
            {
                Destroy(other.gameObject);
            }

            else if (gameObject.name == "IceBall(Clone)")
            {
                // Do Stuff
                GameObject slow = Instantiate(iceSlow, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                Destroy(this.gameObject);
                Destroy(other.gameObject);
            }
            GameObject.Find("PlayerUPDATED(Clone)").GetComponent<Score>().AddScore();
            GameObject.Find("PlayerUPDATED(Clone)").GetComponent<PlayerMana>().AddMaxMana();
        }
    }
}
