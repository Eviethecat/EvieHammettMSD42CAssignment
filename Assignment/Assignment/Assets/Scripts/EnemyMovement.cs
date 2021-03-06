﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] int scoreValue = 5;

    [SerializeField] List<Transform> waypoints;

    [SerializeField] WaveConfig waveConfig;

    //saves the waypoint in which we want to go
    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        //get List waypoints from config
        waypoints = waveConfig.GetWaypoints();

        //Set the start position to the first positioned waypoint
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            //set the targetPosition to where we want to go
            var targetPosition = waypoints[waypointIndex].transform.position;

            //make sure that z axis is 0
            targetPosition.z = 0f;

            var movementThisFrame = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;
            //move enemy from current position to targetPosition, at enemyMovement speed
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            //if enemy reached the target waypoint
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            FindObjectOfType<GameSession>().AddScore(scoreValue);
            Destroy(gameObject);
        }
    }

    //set a WaveConfig
    public void setWaveConfig(WaveConfig waveConfigToSet)
    {
        waveConfig = waveConfigToSet;
    }
}