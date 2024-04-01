using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeTest : MonoBehaviour
{
    // y speed variable
    [SerializeField]
    private float speed;

    // Controls how much theta or the angle in radians should change when calculating the new x position
    private float thetaStep = Mathf.PI / 32f;
    [SerializeField]
    private float theta = 0f;
    // Controls how wide the sine wave becomes.
    [SerializeField]
    private float amplitude = 4f;

    // Controls where the bullet should spawn to ensure the bullet doesn't spawn inside of player ship.
    // This is our k variable in the Sine Function shown above.
    [SerializeField]
    private float xOffset;

    // How stretched or expanded the sine wave is
    // if number > 1, wave will shrink (meaning it will take a shorter time to reach a full sin wave cycle) 
    // if number < 1 but > 0,  wave will stretch out (meaning it will take longer to reach a full sine wave cycle)
    [SerializeField]
    private float waveFrequency = 2f;

    // Determines which direction the sine wave should go initially (e.g. left or right)
    [SerializeField]
    private int waveDirection = 1;
    [SerializeField]
    public bool move = false;


    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        // go between 0 and 2pi
        // need a theta step every update
        // sin wave needs to move relative to the initial position it was shot from
        if (move == true)
        {
            float newXPos = waveDirection * amplitude * Mathf.Sin(theta * waveFrequency) + xOffset;
            //float xStep = newXPos - transform.position.x;

            //transform.Translate(new Vector3(xStep, speed * Time.deltaTime));
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y * newXPos);
            theta += thetaStep;

        }
    }
}
