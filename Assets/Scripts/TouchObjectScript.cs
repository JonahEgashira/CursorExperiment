using System;
using UnityEngine;

public class TouchObjectScript : MonoBehaviour
{
    private const float LimitTime = 0.2f;
    private float _currentTime = 0.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DataStore") && other.enabled)
        {
            other.enabled = false;
            Destroy(other.gameObject);
            ExperimentController.Instance.StoreResultsInDevice();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Target") && other.enabled)
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= LimitTime)
            {
                other.enabled = false;
                Destroy(other.gameObject);
                ExperimentController.Instance.UpdateCubeAndFieldState();
                _currentTime = 0.0f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _currentTime = 0.0f;
    }
}
