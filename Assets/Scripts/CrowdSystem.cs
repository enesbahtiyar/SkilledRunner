using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrowdSystem : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float angle; //137.508 //altın oran
    [SerializeField] float radius;

    [Header("Elements")]
    [SerializeField] Transform RunnerParent;
    [SerializeField] TMP_Text CrowdCounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlaceRunners();
        CountRunners();
    }

    void PlaceRunners()
    {
        for (int i = 0; i < RunnerParent.childCount; i++)
        {
            Vector3 childLocalPosition = GetRunnerLocalPosition(i) * 1;
            RunnerParent.GetChild(i).localPosition = childLocalPosition;
        }
    }

   Vector3 GetRunnerLocalPosition(int index)
    {
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angle);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angle);

        return new Vector3(x, 0, z);
    }

    void CountRunners()
    {
        CrowdCounter.text = RunnerParent.childCount.ToString();
    }
}
