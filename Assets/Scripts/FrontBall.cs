using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontBall : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionExit(Collision other)
    {
        GetComponent<Renderer>().material.color = Color.red;
        ExperimentController.Instance.IncrementFrontBallState();
        Debug.Log("collide with " + other.gameObject.name);
    }
}
