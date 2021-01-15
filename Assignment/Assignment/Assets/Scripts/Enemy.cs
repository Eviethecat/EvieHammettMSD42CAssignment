using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        //access the DamageDealer class from otherObject which hits enemy and reduce health accordingly
        Damage dmgDealer = otherObject.gameObject.GetComponent<Damage>();

        if (!dmgDealer)
        {
            return;
        }
    }

    void Start()
    {
        
    }

    private void Update()
    {
        
    }
}