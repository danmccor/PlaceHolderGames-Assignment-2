using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControls : MonoBehaviour {

	public float speed = 5.0f;
	public float gravity = -9.8f;
	private CharacterController charCont;

    private float collisionTimer = 1.5f;
	// Use this for initialization
	void Start () {
	charCont = GetComponent<CharacterController>();	
	}
	
	// Update is called once per frame
	void Update () {
		float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaZ = Input.GetAxis("Vertical") * speed;

		Vector3 movement = new Vector3 (deltaX, 0, deltaZ);

		movement = Vector3.ClampMagnitude(movement, speed);
		movement.y = gravity;

		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);

		charCont.Move(movement);
	}

    void OnControllerColliderHit(ControllerColliderHit col)
    {
        if (col.gameObject.CompareTag("AI"))
        {
            if(collisionTimer <= 0)
            {
                col.gameObject.GetComponent<AIMovement>().ChangeLayer();
                collisionTimer = 1.5f;
            }
            else
            {
                collisionTimer -= Time.deltaTime;
            }
        }

    }
}
