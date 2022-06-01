using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperimentController : SingletonMonoBehaviour<ExperimentController>
{
    
    private int frontBallState = 0;
    public GameObject frontBall;
    public GameObject rightBall;
    public GameObject leftBall;
    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (frontBall.transform.position.y >= 1.3)
        {
            frontBall.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }
    
    public void Test()
    {
        Debug.Log("Singleton!");
    }

    public void IncrementFrontBallState()
    {
        frontBallState += 1;
    }
}
