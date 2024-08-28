using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class EnemyGroup : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] Enemy enemyPrefab;
    [SerializeField] Transform enemiesParent;

    [Header("Settings")]
    [SerializeField] float angle; //137.508 //altın oran
    [SerializeField] float radius;
    [SerializeField] float enemyAmount;

    private void Start()
    {
        GenerateEnemies();
    }


    void GenerateEnemies()
    {
        for(int i = 0; i < enemyAmount; i++)
        {
            Vector3 enemyLocalPosition = GetRunnerLocalPosition(i);

            Vector3 enemyWorldPosition = transform.TransformPoint(enemyLocalPosition);

            Instantiate(enemyPrefab, enemyWorldPosition, Quaternion.identity, enemiesParent);
        }
    }

    Vector3 GetRunnerLocalPosition(int index)
    {
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angle);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angle);

        return new Vector3(x, 0, z);
    }
}
