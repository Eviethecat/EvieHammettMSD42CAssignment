using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Accessed by Unity
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1.5f;
    [SerializeField] float health = 50f;

    [SerializeField] AudioClip playerDeath;
    [SerializeField] [Range(0, 1)] float playerDeathVolume = 0.5f;

    [SerializeField] AudioClip playerDamage;
    [SerializeField] [Range(0, 1)] float playerDamageVolume = 0.5f;

    [SerializeField] GameObject explosionVFX;
    [SerializeField] float explosionVolume;

    float xMin, xMax, yMin, yMax;

    // Start is called before the first frame update
    void Start()
    {
        MoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        playerMove();
    }

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

        AudioSource.PlayClipAtPoint(playerDamage, Camera.main.transform.position, playerDamageVolume);

        GameObject explosion = Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(explosion, 1f);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(playerDeath, Camera.main.transform.position, playerDeathVolume);

        //Find the Level object and run its methond LoadGameOver()
        FindObjectOfType<LevelScript>().LoadGameOver();
    }

    private void playerMove()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        transform.position = new Vector2(newXPos , yMin);
    }

    //setup boundaries of movement according to the camera
    private void MoveBoundaries()
    {
        Camera gameCam = Camera.main;

        xMin = gameCam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCam.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax= gameCam.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
}
