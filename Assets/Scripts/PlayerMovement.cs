using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public MonoBehaviour planet;
    public CircleCollider2D planetCollider2D;
    public float speed;
    private Vector3 previousPosition;
    public Vector3 pos, velocity, rotationDirection;
    public float distanceToOrbitAroundPlanet = 0.5f;
    private float asteroidSize;
    private bool stayInOrbit = false;


    public void setStayInOrbit(bool stayInOrbit)
    {
        this.stayInOrbit = stayInOrbit;
    }
    void Start()
    {
        previousPosition = transform.position;
    }

    void Update()
    {
        velocity = (transform.position - pos) / Time.deltaTime;
        pos = transform.position;
        Vector3 current = transform.position;
        if (planet != null)
        {
            float dist = Vector3.Distance(planet.transform.position, transform.position);

            if(dist <= 4f)
            {
                stayInOrbit = true;
            }
            Debug.Log("Stay in orbit: " + stayInOrbit);
            if (!stayInOrbit)
            {
                Debug.Log("Distance To Fly To: " + dist);
                FlyToPlanet();
            }
            if(stayInOrbit)
            {
                //Debug.Log("threshold: " + 0.45f);
                //Debug.Log("Distance To Orbit: " + dist);
                OrbitPlanet();
            }
        } else
        {
            stayInOrbit = false;
            transform.position += transform.right * speed * Time.deltaTime;
            this.rotationDirection = Vector3.zero;
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

    public void SetAsteroidSize(float asteroidSize)
    {

        Debug.Log("Asteroid Size: " + asteroidSize);
        this.asteroidSize = asteroidSize;
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

    Vector3 calculateRotationDirection(PlayerMovement orbiter, Transform center)
    {
        Vector3 toCenter = center.position - orbiter.pos;
        float dir = Mathf.Sign(orbiter.velocity.x * toCenter.y - orbiter.velocity.y * toCenter.x);
        if (dir < 0)
        {
            return Vector3.back;
        }
        return Vector3.forward;
        
    }

    private void OrbitPlanet()
    {
        // Do not want to keep setting rotation direction while orbitting
        if (this.rotationDirection == Vector3.zero)
        {
            rotationDirection = calculateRotationDirection(this, planet.transform);
        }

        Vector3 diff = planet.transform.position - transform.position;
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        // Make "side of the ship" face the planet
        var targetRotation = Quaternion.Euler(0f, 0f, rot_z - (90 * rotationDirection.z));
        var step = 2 * speed * 50 * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);

        // Makes ship orbit around the planet
        transform.RotateAround(planet.transform.position, rotationDirection, (speed * 20 * Time.deltaTime));
    }
}
