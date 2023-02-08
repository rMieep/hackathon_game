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
        if(GameObject.Find("Spaceship") is null)
        {
            return;
        }
        playerMovementScript = GameObject.Find("Spaceship").GetComponent<PlayerMovement>();
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked!");
        if(playerMovementScript is null)
        {
            return;
        }
        playerMovementScript.planet = this;
        playerMovementScript.planetCollider2D = this.circleCollider2D;
        playerMovementScript.SetAsteroidSize(gameObject.GetComponent<Asteroid>().size);
    }

    void OnMouseUp()
    {
        Debug.Log("Released!");
        playerMovementScript.setStayInOrbit(false);
        if (playerMovementScript is null)
        {
            return;
        }
        playerMovementScript.planet = null;
        playerMovementScript.planetCollider2D = null;
        playerMovementScript.rotationDirection = Vector3.zero;
    }
}

