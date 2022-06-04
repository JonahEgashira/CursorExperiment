using System;
using UnityEngine;

public class ExperimentController : SingletonMonoBehaviour<ExperimentController>
{
    
    private int _cubeState;
    private const int NumberOfCubeState = 4;
    public GameObject prefabCube;

    private const double Angle = Math.PI * 30.0 / 180.0;
    private const double HypotenuseLength = 10.0;
    private const float BaseX = 0.0f;
    private const float BaseY = 1.125f;
    private const float BaseZ = 0.1f;
    private double _xLength;
    private double _zLength;

    private Vector3 _frontCubePos;
    private Vector3 _rightCubePos;
    private Vector3 _leftCubePos;

    private void Start()
    {
        _xLength = HypotenuseLength * Math.Sin(Angle);
        _zLength = HypotenuseLength * Math.Cos(Angle);
        _frontCubePos = new Vector3(BaseX, BaseY, BaseZ);
        _rightCubePos = new Vector3(BaseX + (float)_xLength, BaseY, BaseZ + (float)_zLength);
        _leftCubePos = new Vector3(BaseX + (float)(-_xLength), BaseY, BaseZ + (float)_zLength);
    }

    public void UpdateCubeState()
    {
        _cubeState += 1;
        _cubeState %= NumberOfCubeState;
        GenerateCube();
        Debug.Log("cubeState: " + _cubeState);
    }

    // TODO: Fix cube position
    private void GenerateCube()
    {
        var ballPos = _cubeState switch
        {
            0 => _frontCubePos,
            1 => _rightCubePos,
            2 => _frontCubePos,
            3 => _leftCubePos,
            _ => _frontCubePos,
        };
        Instantiate(prefabCube, ballPos, Quaternion.identity);
    }
}
