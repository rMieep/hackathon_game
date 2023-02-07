using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public MonoBehaviour planet;
    public float speed;
    private Vector3 previousPosition;

    void Start()
    {
        previousPosition = transform.position;
    }

    void Update()
    {
        Vector3 current = transform.position;
        if (planet != null)
        {
            float dist = Vector3.Distance(planet.transform.position, transform.position);
            Debug.Log("Dist: " + dist);

            if (dist > 2f)
            {
                FlyToPlanet();
            }
            else
            {
                OrbitPlanet();
            }
        } else
        {
            Debug.Log("Previous Pos: " + previousPosition);
            Debug.Log("Current Pos: " + transform.position);
            Vector3 direction = -(previousPosition - transform.position);
            direction.Normalize();
            transform.Translate(direction * speed * Time.deltaTime);
        }

        previousPosition = current;
    }

    private void FlyToPlanet()
    {
        Debug.Log("Planet Position: " + planet.transform.position);
        // Vector3 direction = planet.transform.position - transform.position;
        // direction.Normalize();
        transform.position = Vector3.MoveTowards(transform.position, planet.transform.position, speed * Time.deltaTime);
        
    }

    private void OrbitPlanet()
    {
        Vector3 diff = planet.transform.position - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        transform.RotateAround(planet.transform.position, new Vector3(0, 0, 100), 50 * Time.deltaTime);
    }
 

}
