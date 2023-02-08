using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    //public ParticleSystem explosionParticleSystem;
    public GameOverScreen GameOverScreen;

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        Debug.Log("Game Over! on collision");
        //explosionParticleSystem.transform.position = this.transform.position;
        //explosionParticleSystem.Simulate(1);
        //explosionParticleSystem.Play(true);
        Destroy(this.gameObject);
        GameOverScreen.Setup(100);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Game Over! on trigger");
        //explosionParticleSystem.transform.position = this.transform.position;
        //explosionParticleSystem.Simulate(1);
        //explosionParticleSystem.Play(true);
        GameOverScreen.Setup(100);
        Destroy(this.gameObject);
    }
}
