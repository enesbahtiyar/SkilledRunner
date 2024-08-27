using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] Chunk[] chunkPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 chunkPosition = Vector3.zero;
        for (int i = 0; i < 4; i++)
        {
            Chunk chunkToCreate = chunkPrefabs[Random.Range(0, chunkPrefabs.Length)];

            if (i > 0)
            {
                chunkPosition.z += chunkToCreate.GetLength() / 2;
            }

            Chunk chunkInstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity);

            chunkPosition.z += chunkInstance.GetLength() / 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
