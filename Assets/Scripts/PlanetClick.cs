using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetClick : MonoBehaviour
{
    private PlayerMovement playerMovementScript;
    CircleCollider2D circleCollider2D;

    void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
        playerMovementScript = GameObject.Find("Spaceship").GetComponent<PlayerMovement>();
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked!");
        playerMovementScript.planet = this;
        playerMovementScript.planetCollider2D = this.circleCollider2D;
    }

    void OnMouseUp()
    {
        Debug.Log("Released!");
        playerMovementScript.planet = null;
        playerMovementScript.planetCollider2D = null;
    }
}
