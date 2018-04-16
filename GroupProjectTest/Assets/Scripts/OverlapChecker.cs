using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapChecker : MonoBehaviour {

    void OnCollisionStay(Collision coll)
    {
        if(coll.transform.tag == "SpawnChunk")
        {
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
    }
}
