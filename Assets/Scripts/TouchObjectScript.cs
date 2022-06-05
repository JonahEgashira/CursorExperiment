using UnityEngine;

public class TouchObjectScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target") && other.enabled)
        {
            other.enabled = false;
            Destroy(other.gameObject);
            Debug.Log("Enter Called");
            ExperimentController.Instance.UpdateCubeState();
        }
    }
}
