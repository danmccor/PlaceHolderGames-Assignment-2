/* 
 * Author: Daniel McCormick 
 * Project: Blackthorn Manor
 * Version: 1.0.0
 * Description: The script that controls the players movement around the map. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl2 : MonoBehaviour
{
    public float walkAcceleration = 10f;
    public float walkDeacceleration = 10f;
    public GameObject cameraObj;
    public float maxWalkSpeed = 20f;

    Vector2 horizontalMovement; 

    private Rigidbody rb; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
     
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = new Vector2(rb.velocity.x, rb.velocity.z);
        if(horizontalMovement.magnitude > maxWalkSpeed)
        {
            horizontalMovement = horizontalMovement.normalized;
            horizontalMovement *= maxWalkSpeed;
        }

        rb.velocity = new Vector3(horizontalMovement.x, rb.velocity.y, horizontalMovement.y);

        if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            rb.velocity = new Vector3(rb.velocity.x / walkDeacceleration, rb.velocity.y, rb.velocity.z / walkDeacceleration);
        }

        transform.rotation = Quaternion.Euler(0, cameraObj.GetComponent<cameraController2>().currentYRotation, 0);
        rb.AddRelativeForce(walkAcceleration * Input.GetAxis("Horizontal"), 0, walkAcceleration * Input.GetAxis("Vertical"));

    }
}
