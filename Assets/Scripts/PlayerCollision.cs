using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    //public ParticleSystem explosionParticleSystem;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Game Over!");
        //explosionParticleSystem.transform.position = this.transform.position;
        //explosionParticleSystem.Simulate(1);
        //explosionParticleSystem.Play(true);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Game Over!");
        //explosionParticleSystem.transform.position = this.transform.position;
        //explosionParticleSystem.Simulate(1);
        //explosionParticleSystem.Play(true);
        Destroy(this.gameObject);
    }
}
