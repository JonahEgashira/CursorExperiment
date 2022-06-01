using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideTest : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        GetComponent<Renderer>().material.color = Color.red;
        Debug.Log("collide with " + other.gameObject.name);
    }
}
