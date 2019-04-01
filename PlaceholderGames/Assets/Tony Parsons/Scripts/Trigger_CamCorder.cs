using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_CamCorder : MonoBehaviour
{
    public GameObject The_Event;
    private bool isActive;

    private void Start()
    {
        isActive = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isActive)
        {
            The_Event.SetActive(true);
            isActive = true;
        }
    }
}
