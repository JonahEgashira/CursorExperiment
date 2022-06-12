using System;
using UnityEngine;

public class TouchObjectScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target") && other.enabled)
        {
            other.enabled = false;
            Destroy(other.gameObject);
            ExperimentController.Instance.UpdateCubeAndFieldState();
        }

        if (other.gameObject.CompareTag("DataStore") && other.enabled)
        {
            other.enabled = false;
            Destroy(other.gameObject);
            ExperimentController.Instance.StoreResultsInDevice();
        }
    }
}
