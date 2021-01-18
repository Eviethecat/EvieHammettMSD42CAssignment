using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 1f;

    [SerializeField] GameObject explosionVFX;
    [SerializeField] float explosionTime;

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        //access the DamageDealer class from otherObject which hits enemy and reduce health accordingly
        Damage dmgDealer = otherObject.gameObject.GetComponent<Damage>();


        if (!dmgDealer)
        {
            return;
        }

        ProcessHit(dmgDealer);
    }

    private void ProcessHit(Damage dmgDealer)
    {
        health -= dmgDealer.GetDamage();
        dmgDealer.Hit();

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        GameObject explosion = Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(explosion, 1f);
    }
}