using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] Chunk chunkPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 chunkPosition = Vector3.zero;
        for (int i = 0; i < 4; i++)
        {
            Chunk chunkInstance = Instantiate(chunkPrefab, chunkPosition, Quaternion.identity);

            chunkPosition.z += chunkInstance.GetLength();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
