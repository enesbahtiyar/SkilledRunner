using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] CrowdSystem crowdSystem;
    [SerializeField] float roadWidth;

    [Header("Move Settings")]
    [Tooltip("Adjust the slider to change the speed of the character")]
    [SerializeField] float speed;

    [Header("Slider Settings")]
    [SerializeField] float slideSpeed;
    [SerializeField] Vector3 clickedScreenPosition;
    [SerializeField] Vector3 clickedPlayerPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
        SlideCharacter();
    }

    void MoveCharacter()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }

    void SlideCharacter()
    {
        if(Input.GetMouseButtonDown(0))
        {
            clickedScreenPosition = Input.mousePosition;
            clickedPlayerPosition = transform.position;
        }
        else if(Input.GetMouseButton(0))
        {
            float xScreenDifference = Input.mousePosition.x - clickedScreenPosition.x;

            xScreenDifference /= Screen.width;
            xScreenDifference *= slideSpeed;

            Vector3 position = transform.position;
            position.x = xScreenDifference;

            position.x = Mathf.Clamp(position.x, -roadWidth / 2 + crowdSystem.GetCrowdRadius(), roadWidth / 2 - crowdSystem.GetCrowdRadius());

            transform.position = position;

            //transform.position = clickedPlayerPosition + Vector3.right * xScreenDifference;
        }
    }
}
