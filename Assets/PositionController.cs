using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionController : MonoBehaviour
{
    public GameObject cameraRig;

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickDown))
        {
            cameraRig.transform.position += Vector3.down * 0.01f;
        }

        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickUp))
        {
            cameraRig.transform.position += Vector3.up * 0.01f;
        }

        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickRight))
        {
            cameraRig.transform.position += Vector3.right * 0.01f;
        }

        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstickLeft))
        {
            cameraRig.transform.position += Vector3.left * 0.01f;
        }
        
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            cameraRig.transform.position += Vector3.forward * 0.01f;
        }
        
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            cameraRig.transform.position += Vector3.back * 0.01f;
        }
        
    }
}