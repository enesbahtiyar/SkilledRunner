using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] CrowdSystem crowdSystem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectDoors();
    }

    void DetectDoors()
    {
        Collider[] detectedColliders = Physics.OverlapSphere(transform.position, 1);

        for(int i = 0; i < detectedColliders.Length; i++)
        {
            if (detectedColliders[i].TryGetComponent(out DoorLogic doors))
            {
                doors.DisableCollider();
                //şu an kapıya çarptığımızı biliyoruz
                Debug.Log("Kapıya çarptık");

                //burada kapıya çarptığımızda ne olması gerektiğine
                int bonusAmount = doors.GetBonus(transform.position.x);
                BonusType bonusType = doors.GetBonusType(transform.position.x);

                crowdSystem.ApplyBonus(bonusType, bonusAmount);



            }
        }
    }
}
