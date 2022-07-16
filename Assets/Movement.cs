using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector2 startingMousePosition;
    public float divisor = 100f;
    Quaternion tilt;
    public float maxXTiltAngle = 30;
    public float maxYTiltAngle = 30;
    public GameObject ball;
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        startingMousePosition = new Vector2(Screen.width/2, Screen.height/2);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newMousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 directionVector = (startingMousePosition - newMousePosition);

        //Debug.Log(directionVector);

        float xMovement = directionVector.x / divisor;
        float yMovement = - (directionVector.y / divisor * 3);

        if (xMovement > maxXTiltAngle)
        {
            xMovement = maxXTiltAngle;
        }
        if(xMovement < -maxXTiltAngle)
        {
            xMovement = -maxXTiltAngle;
        }
        if(yMovement > maxYTiltAngle)
        {
            yMovement = maxYTiltAngle;
        }
        if(xMovement < -maxYTiltAngle)
        {
            yMovement = -maxYTiltAngle;
        }


        Debug.Log("x: " + xMovement + "y: " +  yMovement);

        tilt = Quaternion.Euler(yMovement, 0, xMovement);
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, tilt, Time.deltaTime * speed);
    }
}
