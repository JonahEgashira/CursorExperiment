using System;
using UnityEngine;

public class ExperimentController : SingletonMonoBehaviour<ExperimentController>
{
    
    private int _cubeState;
    private int _touchedCount;
    private const int NumberOfCubeState = 4;
    public GameObject prefabCube;
    public GameObject rightHandAnchor;
    public GameObject rightHand;

    private const double Degree = 30.0;
    private const double ShiftAngle = Math.PI * 1.0 / 180.0;
    private const double HypotenuseLength = 0.3;
    private const float BaseX = 0.0f;
    private const float BaseY = 1.125f;
    private const float BaseZ = 0.1f;
    private double _angle;
    private double _xLength;
    private double _zLength;

    private Vector3 _frontCubePos;
    private Vector3 _rightCubePos;
    private Vector3 _leftCubePos;

    private void Start()
    {
        _angle = Math.PI * Degree / 180.0;
        _xLength = HypotenuseLength * Math.Sin(_angle);
        _zLength = HypotenuseLength * Math.Cos(_angle);
        _frontCubePos = new Vector3(BaseX, BaseY, BaseZ);
        _rightCubePos = new Vector3(BaseX + (float)_xLength, BaseY, BaseZ + (float)_zLength);
        _leftCubePos = new Vector3(BaseX + (float)(-_xLength), BaseY, BaseZ + (float)_zLength);
    }

    private void Update()
    {
        ShiftRightHand();
    }

    private void ShiftRightHand()
    {
        var turn = _touchedCount / NumberOfCubeState;
        var angle = turn * ShiftAngle;

        var zDistance = rightHand.transform.position.z - BaseZ;
        var xAdjustment = zDistance * Math.Tan(angle);

        var anchorPos = rightHandAnchor.transform.position;
        switch (_cubeState)
        {
            case 0 or 3:
                rightHand.transform.position = anchorPos + new Vector3((float)-xAdjustment,0, 0);
                break;
            case 1 or 2:
                rightHand.transform.position = anchorPos + new Vector3((float)xAdjustment,0, 0);
                break;
        }
    }

    public void UpdateCubeState()
    {
        _touchedCount += 1;
        _cubeState += 1;
        _cubeState %= NumberOfCubeState;
        Invoke(nameof(GenerateCube), 0.3f);
        Debug.Log("cubeState: " + _cubeState);
    }

    private void GenerateCube()
    {
        var cubePos = _cubeState switch
        {
            0 => _frontCubePos,
            1 => _rightCubePos,
            2 => _frontCubePos,
            3 => _leftCubePos,
            _ => _frontCubePos,
        };
        Instantiate(prefabCube, cubePos, Quaternion.identity);
    }
}
