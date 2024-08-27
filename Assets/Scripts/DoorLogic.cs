using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorLogic : MonoBehaviour
{
    enum BonusType
    {
        Addition,
        Difference
    }

    [Header("Elements")]
    [SerializeField] SpriteRenderer leftDoorRenderer;
    [SerializeField] SpriteRenderer rightDoorRenderer;
    [SerializeField] TMP_Text rightDoorText;
    [SerializeField] TMP_Text leftDoorText;

    [Header("Settings")]
    [SerializeField] BonusType rightDoorBonusType;
    [SerializeField] int rightDoorAmount;

    [SerializeField] BonusType leftDoorBonusType;
    [SerializeField] int leftDoorAmount;

    [SerializeField] Color bonusColor;
    [SerializeField] Color penaltyColor;
    // Start is called before the first frame update
    void Start()
    {
        ConfigureDoors();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ConfigureDoors()
    {
        if (rightDoorBonusType == BonusType.Addition)
        {
            rightDoorRenderer.color = bonusColor;
            rightDoorText.text = "+" + rightDoorAmount;
        }
        else if (rightDoorBonusType == BonusType.Difference)
        {
            rightDoorRenderer.color = penaltyColor;
            rightDoorText.text = "-" + rightDoorAmount;
        }


        if (leftDoorBonusType == BonusType.Addition)
        {
            leftDoorRenderer.color = bonusColor;
            leftDoorText.text = "+" + leftDoorAmount;
        }
        else if (leftDoorBonusType == BonusType.Difference)
        {
            leftDoorRenderer.color = penaltyColor;
            leftDoorText.text = "-" + leftDoorAmount;
        }
    }
}
