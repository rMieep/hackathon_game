using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetClick : MonoBehaviour
{
    private PlayerMovement playerMovementScript;

    void Start()
    {
        playerMovementScript = GameObject.Find("Spaceship").GetComponent<PlayerMovement>();
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked!");
        playerMovementScript.planet = this;
    }

    void OnMouseUp()
    {
        Debug.Log("Released!");
        playerMovementScript.planet = null;
    }
}
