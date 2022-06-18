using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI lengthValue;
    public TextMeshProUGUI additionalCount;

    // Update is called once per frame
    void Update()
    {
        lengthValue.text = ExperimentController.Instance.hypotenuseLength.ToString(CultureInfo.InvariantCulture);
        additionalCount.text = ExperimentController.Instance.AdditionalCount.ToString();
    }

    public void incrementLength()
    {
        ExperimentController.Instance.hypotenuseLength += 0.01;
    }

    public void decrementLength()
    {
        ExperimentController.Instance.hypotenuseLength -= 0.01;
    }

    public void incrementAdditionalCount()
    {
        ExperimentController.Instance.AdditionalCount += 1;
    }
    
    public void decrementAdditionalCount()
    {
        ExperimentController.Instance.AdditionalCount -= 1;
    }
    
}
