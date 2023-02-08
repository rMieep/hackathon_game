using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Asteroid : MonoBehaviour
{
    public Rigidbody2D rigidbody { get; private set; }
    public SpriteRenderer spriteRenderer { get; private set; }
    public Sprite[] sprites;

    public float size;
    public float minSize;
    public float maxSize ;
    public float movementSpeed;
    public float maxLifetime;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // Assign random properties to make each asteroid feel unique
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360f);

        // Set the scale and mass of the asteroid based on the assigned size so
        // the physics is more realistic
        transform.localScale = Vector3.one * size;
        rigidbody.mass = size;

        // Destroy the asteroid after it reaches its max lifetime
    }

    public void SetTrajectory()
    {
        // The asteroid only needs a force to be added once since they have no
        // drag to make them stop moving
       // rigidbody.AddForce(direction * movementSpeed);
        rigidbody.velocity = rigidbody.GetRelativeVector(Vector3.left).normalized * movementSpeed;
        // Destroy the asteroid after it reaches its max lifetime
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Astroid destroyed");
        //explosionParticleSystem.transform.position = this.transform.position;
        //explosionParticleSystem.Simulate(1);
        //explosionParticleSystem.Play(true);
        Destroy(this.gameObject);
    }
}