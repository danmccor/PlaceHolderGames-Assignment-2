using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour {
    private GameObject player;
	public enum rotationAxis{
	mouseX = 1, mouseY = 2
	}
	public rotationAxis axes = rotationAxis.mouseX;
	public float minimumVert = -45.0f;
	public float maximumVert = 45.0f;


	public float sensHorizontal = 10.0f;
	public float sensVertical = 10.0f;
	public float rotationX = 0;
	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<playerControls>().PlayerCanMove)
        {
            if (axes == rotationAxis.mouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensHorizontal, 0);
            }
            else if (axes == rotationAxis.mouseY)
            {
                rotationX -= Input.GetAxis("Mouse Y") * sensVertical;
                rotationX = Mathf.Clamp(rotationX, minimumVert, maximumVert);
                float rotationY = transform.localEulerAngles.y;
                transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
            }
        }
    }
}
