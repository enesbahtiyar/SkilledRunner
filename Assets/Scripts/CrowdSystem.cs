using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CrowdSystem : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float angle; //137.508 //altın oran
    [SerializeField] float radius;

    [Header("Elements")]
    [SerializeField] Transform RunnerParent;

    [SerializeField] GameObject runnerPrefab;

    // Update is called once per frame
    void Update()
    {
        PlaceRunners();
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



    public float GetCrowdRadius()
    {
        return radius * Mathf.Sqrt(RunnerParent.childCount);
    }

    public void ApplyBonus(BonusType bonusType, int bonusAmount)
    {
        if(bonusType == BonusType.Addition)
        {
            AddRunners(bonusAmount);
        }
        else if (bonusType == BonusType.Difference)
        {
            SubtrackRunners(bonusAmount);
        }
    }

    private void SubtrackRunners(int bonusAmount)
    {
        if(bonusAmount > RunnerParent.childCount)
            bonusAmount = RunnerParent.childCount;

        int runnersAmount = RunnerParent.childCount;

        for (int i = runnersAmount - 1; i >= runnersAmount - bonusAmount; i--)
        {
            Transform runnerToDestroy = RunnerParent.GetChild(i);
            runnerToDestroy.SetParent(null);

            Destroy(runnerToDestroy.gameObject);
        }
    }

    private void AddRunners(int bonusAmount)
    {
        for (int i = 0; i < bonusAmount; i++)
        {
            Instantiate(runnerPrefab, RunnerParent);
        }
    }
}
