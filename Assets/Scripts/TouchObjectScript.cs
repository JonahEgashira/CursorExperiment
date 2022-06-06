using System;
using UnityEngine;

public class TouchObjectScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Target") || !other.enabled) return;
        other.enabled = false;
        Destroy(other.gameObject);
        ExperimentController.Instance.UpdateCubeAndFieldState();
    }
}
