using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperimentController : SingletonMonoBehaviour<ExperimentController>
{
    
    private int frontBallState = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
