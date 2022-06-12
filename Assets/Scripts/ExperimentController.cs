using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ExperimentController : SingletonMonoBehaviour<ExperimentController>
{
    
    private int _cubeState;
    private int _touchedCount;
    private int _frameCount;
    private const int MaxTouchedCount = 120;
    private const int NumberOfCubeState = 4;
    
    public GameObject prefabCube;
    public GameObject rightHandAnchor;
    public GameObject rightHand;

    private const double Degree = 30.0;
    private const double MaxAngle = Math.PI * 30.0 / 180.0;
    private const double ShiftAngle = Math.PI * 0.5 / 180.0;
    private const double HypotenuseLength = 0.2;
    private const float CubeBaseX = 0.0f;
    private const float CubeBaseY = 1.125f;
    private const float CubeBaseZ = 0.10f;
    
    private float _forceFieldBaseZ;
    
    private double _angle;
    private double _xLength;
    private double _zLength;

    private Vector3 _frontCubePos;
    private Vector3 _rightCubePos;
    private Vector3 _leftCubePos;

    private readonly List<string> _actualRightHandPositions = new();

    private void Start()
    {
        _cubeState = 0;
        _touchedCount = 0;
        _frameCount = 0;
        
        _angle = Math.PI * Degree / 180.0;
        _xLength = HypotenuseLength * Math.Sin(_angle);
        _zLength = HypotenuseLength * Math.Cos(_angle);
        _frontCubePos = new Vector3(CubeBaseX, CubeBaseY, CubeBaseZ);
        _rightCubePos = new Vector3(CubeBaseX + (float)_xLength, CubeBaseY, CubeBaseZ + (float)_zLength);
        _leftCubePos = new Vector3(CubeBaseX + (float)(-_xLength), CubeBaseY, CubeBaseZ + (float)_zLength);
    }

    private void Update()
    {
        ShiftRightHand();
        _frameCount++;

        if (_frameCount % 5 == 0)
        {
            PushRightHandPosition();
        }

        if (_touchedCount == MaxTouchedCount)
        {
            StoreResultsInPC();
            StoreResultsInDevice();
        }
    }

    private void ShiftRightHand()
    {
        var turn = _touchedCount / NumberOfCubeState;
        var angle = Math.Min(turn * ShiftAngle, MaxAngle);

        var actualPosition = rightHandAnchor.transform.position;
        var virtualPosition = rightHand.transform.position;
        var zDistance = actualPosition.z - _forceFieldBaseZ;
        var xAdjustment = zDistance >= -0.1 ? zDistance * Math.Tan(angle) : 0.0;

        virtualPosition = _cubeState switch
        {
            0 or 3 => actualPosition + new Vector3((float)-xAdjustment, 0, 0),
            1 or 2 => actualPosition + new Vector3((float)xAdjustment, 0, 0),
            _ => virtualPosition
        };
        rightHand.transform.position = virtualPosition;
    }

    public void UpdateCubeAndFieldState()
    {
        if (_cubeState is 0 or 2)
        {
            var position = rightHandAnchor.transform.position;
            _forceFieldBaseZ = position.z;
        }
        
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

    private void PushRightHandPosition()
    {
        var actualPosition = rightHandAnchor.transform.position;
        _actualRightHandPositions.Add(_cubeState + "," + actualPosition.x + "," + actualPosition.y + "," + actualPosition.z);
    }

    private void StoreResultsInPC()
    {
        var dateStr = DateTime.Now.ToString("MM_dd_HH_mm");
        var path = Application.dataPath + "/HandPositions/";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        var filePath = path + dateStr + ".csv";
        File.WriteAllLines(filePath, _actualRightHandPositions);
    }

    public void StoreResultsInDevice()
    {
        var dateStr = DateTime.Now.ToString("MM_dd_HH_mm");
        var path = Application.persistentDataPath + "/HandPositions/";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        var filePath = path + dateStr + ".csv";
        File.WriteAllLines(filePath, _actualRightHandPositions);
    }

}
