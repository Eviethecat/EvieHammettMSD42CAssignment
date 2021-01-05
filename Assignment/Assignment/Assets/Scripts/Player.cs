using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Accessed by Unity
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1.5f;

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
