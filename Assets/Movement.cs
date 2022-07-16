using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector2 startingMousePosition;
    public float divisor = 100f;
    public float speed = 1f;
    public float movementForce = 1f;
    public float angleIncrease = 1f;
    public float maxTiltAngle = 45f;

    Quaternion tilt;
    

    // Start is called before the first frame update
    void Start()
    {
        startingMousePosition = new Vector2(Screen.width/2, Screen.height/2);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newMousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 directionVector = (newMousePosition - startingMousePosition).normalized;

        Quaternion currrentQuaternion = transform.rotation;
        Quaternion nextQuaternion = currrentQuaternion;

        float possibleXAngleIcrease = -(directionVector.x * angleIncrease);

        Debug.Log(possibleXAngleIcrease);

        //Mouse on right side of the screen
        if(possibleXAngleIcrease < 0)
        {
            if(currrentQuaternion.eulerAngles.z > -maxTiltAngle)
            {
                nextQuaternion = Quaternion.Euler(nextQuaternion.eulerAngles.x, nextQuaternion.eulerAngles.y, nextQuaternion.eulerAngles.z + possibleXAngleIcrease);
            }
            else
            {
                //do nothing, next quaternion is already fine
            }
        }
        //Mouse on the left side of the screen
        else
        {
            Debug.Log("ANGLE IS :" + currrentQuaternion.eulerAngles.z);
            Debug.Log("maxTiltIs : " + maxTiltAngle);
            if(currrentQuaternion.eulerAngles.z -360 < maxTiltAngle)
            {
                nextQuaternion = Quaternion.Euler(nextQuaternion.eulerAngles.x, nextQuaternion.eulerAngles.y, nextQuaternion.eulerAngles.z + possibleXAngleIcrease);
            }
        }
        tilt = nextQuaternion;
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, tilt, Time.deltaTime * speed);
    }
}
