using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour {
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
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (axes == rotationAxis.mouseX) {
			transform.Rotate (0, Input.GetAxis ("Mouse X") * sensHorizontal, 0);
		} else if (axes == rotationAxis.mouseY) {
			rotationX -= Input.GetAxis("Mouse Y") * sensVertical;
			rotationX = Mathf.Clamp(rotationX, minimumVert, maximumVert);
			float rotationY = transform.localEulerAngles.y;
			transform.localEulerAngles = new Vector3 (rotationX, rotationY, 0);
		}
	}
}
