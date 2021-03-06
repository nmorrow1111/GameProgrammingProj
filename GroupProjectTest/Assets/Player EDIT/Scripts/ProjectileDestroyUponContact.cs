﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroyUponContact : MonoBehaviour {

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("SpawnChunk"))
        {
            Destroy(this.gameObject);
        }
    }
}
