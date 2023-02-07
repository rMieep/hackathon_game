using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid asteroidPrefab;
    public float spawnDistance = 15f;
    public float spawnRate = 6f;
    public int amountPerSpawn = 1;
    //[Range(0f, 45f)]
    public float trajectoryVariance = 15f;

    private void Start()
    {
        InvokeRepeating("Spawn", spawnRate, spawnRate);
    }

    public void Spawn()
    {


        // Choose a random direction from the center of the spawner and
        // spawn the asteroid a distance away
        Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance; ;
        Vector3 spawnPoint = this.transform.position + spawnDirection;

        // Offset the spawn point by the position of the spawner so its
        // relative to the spawner location
        //spawnPoint += transform.position;

        // Calculate a random variance in the asteroid's rotation which will
        // cause its trajectory to change
        float variance = Random.Range(trajectoryVariance, trajectoryVariance);
        Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

        // Create the new asteroid by cloning the prefab and set a random
        // size within the range
        Asteroid asteroid = Instantiate(asteroidPrefab, spawnPoint, Quaternion.identity);
        asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
        Vector2 trajectory = rotation * -spawnDirection;
        asteroid.SetTrajectory(trajectory);

    }

}