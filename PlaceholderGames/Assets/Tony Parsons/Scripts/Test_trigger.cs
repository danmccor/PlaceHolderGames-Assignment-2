using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_trigger : MonoBehaviour
{
    public GameObject The_Event;

    private void OnTriggerEnter(Collider other)
    {
        The_Event.SetActive(true);
    }
}
