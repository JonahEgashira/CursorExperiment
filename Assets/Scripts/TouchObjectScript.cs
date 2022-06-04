using UnityEngine;

public class TouchObjectScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            Destroy(other.gameObject);
            ExperimentController.Instance.UpdateCubeState();
        }
    }
}
