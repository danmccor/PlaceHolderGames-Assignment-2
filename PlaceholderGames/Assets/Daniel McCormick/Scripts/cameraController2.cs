using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController2 : MonoBehaviour
{
    public float lookSensitivity = 5f;
    public float yDegreeLock = 45f;
    float yRotation;
    float xRotation;
    public float currentXRotation;
    public float currentYRotation;
    float xRotationVelocity;
    float yRotationVelocity;
    public float lookSmoothing = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        yRotation += Input.GetAxis("Mouse X") * lookSensitivity;
        xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;

        xRotation = Mathf.Clamp(xRotation, -yDegreeLock, yDegreeLock);

        currentXRotation = Mathf.SmoothDamp(currentXRotation, xRotation, ref xRotationVelocity, lookSmoothing);
        currentYRotation = Mathf.SmoothDamp(currentYRotation, yRotation, ref yRotationVelocity, lookSmoothing);



        transform.rotation = Quaternion.Euler(currentXRotation, currentYRotation, 0);


    }
}
