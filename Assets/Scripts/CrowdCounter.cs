using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrowdCounter : MonoBehaviour
{

    [SerializeField] Transform objectParent;
    [SerializeField] TMP_Text crowdCounter;

    private void Update()
    {
        CountRunners();
    }

    void CountRunners()
    {
        crowdCounter.text = objectParent.childCount.ToString();
    }
}
