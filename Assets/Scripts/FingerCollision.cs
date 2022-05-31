using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision other)
    {
        Debug.Log("Colliding with" + other.gameObject.name);
    }
}
