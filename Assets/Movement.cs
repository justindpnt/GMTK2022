using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector2 startingMousePosition;
    public float divisor = 100f;
    public float speed = 1f;
    Quaternion tilt;
    

    // Start is called before the first frame update
    void Start()
    {
        startingMousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newMousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 directionVector = (startingMousePosition - newMousePosition);

        //Debug.Log(directionVector);

        float xMovement = directionVector.x / divisor;
        float yMovement = directionVector.y / divisor * 2;

        Debug.Log("x: " + xMovement + "y: " +  yMovement);

        tilt = Quaternion.Euler(-yMovement, 0, xMovement);
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, tilt, Time.deltaTime * speed);
    }
}
