using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid asteroidPrefab;
    public float spawnDistance = 15f;
    public float spawnRate = 1f;
    public int amountPerSpawn = 1;
    //[Range(0f, 45f)]
    public float trajectoryVariance = 15f;

    private void Start()
    {
        InvokeRepeating("Spawn", spawnRate, 4f);
    }

    public void Spawn()
    {


        Vector3 randomSpawnPosition = new Vector3(Random.Range(25, 30), Random.Range(10, -10), Random.Range(-10, 11));

        // Calculate a random variance in the asteroid's rotation which will
        // cause its trajectory to change
        float variance = Random.Range(trajectoryVariance, trajectoryVariance);
        Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

        // Create the new asteroid by cloning the prefab and set a random
        // size within the range
        Asteroid asteroid = Instantiate(asteroidPrefab, randomSpawnPosition, Quaternion.identity);
        //asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
        asteroid.size = 3;
        //Vector2 trajectory = rotation * -spawnDirection;
        asteroid.SetTrajectory();

    }

}