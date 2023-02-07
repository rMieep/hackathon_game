using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public MonoBehaviour planet;
    public CircleCollider2D planetCollider2D;
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

            if (dist > 2.1f)
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

    Vector3 PositionInCircumference(Vector3 center, float radius, float degrees)
    {
        float radians = degrees * Mathf.Deg2Rad;
        float x = Mathf.Cos(radians);
        float y = Mathf.Sin(radians);
        Vector3 position = new Vector3(x, y, 0);
        position *= radius;
        position += center;

        return position;
    }

    private void FlyToPlanet()
    {
        // Aim for either right or left side of the planet (Trial and error) (Still working on this!)
        // Have to use: planetCollider2D.radius
        var new_position = this.PositionInCircumference(planet.transform.position, 2f, 36);
        Debug.Log("Old Position -> " + planet.transform.position);
        Debug.Log("New Position -> " + new_position);

        // Make "front" of the ship face the planet
        Vector3 diff = new_position - transform.position;
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        var targetRotation = Quaternion.Euler(0f, 0f, rot_z);

        // 50 was just set randomly as it seemed like a smooth constant for rotation (trial and error)
        var step = speed * 50 * Time.deltaTime;

        // Gently rotate the ship
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);

        // Move ship "towards" the planet
        transform.position = Vector3.MoveTowards(transform.position, new_position, speed * Time.deltaTime);
    }

    private void OrbitPlanet()
    {
        Vector3 targetDir = planet.transform.position - transform.position;
        Debug.Log(Vector3.SignedAngle(targetDir, transform.right, Vector3.right));
        Debug.Log("Orbiting");
        Vector3 diff = planet.transform.position - transform.position;
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        // Make "side of the ship" face the planet
        var targetRotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        var step = speed * 50 * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);

        // Makes ship orbit around the planet
        transform.RotateAround(planet.transform.position, Vector3.forward, (speed * 20 * Time.deltaTime));
    }
 

}
