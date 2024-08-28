using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public enum BonusType{ Addition, Difference}

public class DoorLogic : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] SpriteRenderer leftDoorRenderer;
    [SerializeField] SpriteRenderer rightDoorRenderer;
    [SerializeField] TMP_Text rightDoorText;
    [SerializeField] TMP_Text leftDoorText;
    [SerializeField] Collider collider;

    [Header("Settings")]
    [SerializeField] BonusType rightDoorBonusType;
    [SerializeField] int rightDoorAmount;

    [SerializeField] BonusType leftDoorBonusType;
    [SerializeField] int leftDoorAmount;

    [SerializeField] Color bonusColor;
    [SerializeField] Color penaltyColor;

    void Start()
    {
        ConfigureDoors();
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

    public int GetBonus(float xPosition)
    {
        if (xPosition > 0)
            return rightDoorAmount;
        else 
            return leftDoorAmount;
    }

    public BonusType GetBonusType(float xPosition)
    {
        if (xPosition > 0)
            return rightDoorBonusType;
        else
            return leftDoorBonusType;
    }

    public void DisableCollider()
    {
        collider.enabled = false;
    }
}
