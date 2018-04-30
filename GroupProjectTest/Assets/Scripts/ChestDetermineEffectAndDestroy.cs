using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDetermineEffectAndDestroy : MonoBehaviour {
    public GameObject player;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.Equals(player))
        {
            float randomNum = Random.value;

            Debug.Log("ANYTHING?");
            player.GetComponent<PlayerMana>().ResetMana();
            
            if (randomNum > .75f)
            {
                Debug.Log("ANYTHING?");
                player.GetComponent<PlayerHealth>().ResetHealth();
            }
            else if (randomNum == .50f)
            {
                Debug.Log("ANYTHING?");
                player.GetComponent<PlayerMana>().ResetMana();
                player.GetComponent<PlayerHealth>().ResetHealth();
            }
            Destroy(this.gameObject);
        }
    }
}
