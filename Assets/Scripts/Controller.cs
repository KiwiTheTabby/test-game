using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Transform playerTransform;

    public float moveSpeed;
    public float topSpeed;
    public float horizontalVelocity;
    public float verticalVelocity;
    public float friction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) { verticalVelocity += moveSpeed; }
        if (Input.GetKey(KeyCode.S)) { verticalVelocity -= moveSpeed; }
        if (Input.GetKey(KeyCode.A)) { horizontalVelocity -= moveSpeed; }
        if (Input.GetKey(KeyCode.D)) { horizontalVelocity += moveSpeed; }

        horizontalVelocity *= friction;
        verticalVelocity *= friction;

        if (Mathf.Abs(verticalVelocity) < 1) { verticalVelocity = 0; }
        if (Mathf.Abs(horizontalVelocity) < 1) { horizontalVelocity = 0;}

        if ( horizontalVelocity >= topSpeed ) { horizontalVelocity = topSpeed; }
        else if (horizontalVelocity <= -topSpeed ) { horizontalVelocity = -topSpeed; }

        if (verticalVelocity >= topSpeed) { verticalVelocity = topSpeed; }
        else if (verticalVelocity <= -topSpeed) { verticalVelocity = -topSpeed; }

        transform.Translate(horizontalVelocity * Time.deltaTime, verticalVelocity * Time.deltaTime, 0);
        

    }
}
