using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventTriggers : MonoBehaviour
{
    
    public GameObject manager;
    private eventManager eventcheck;
    // Start is called before the first frame update
    void Start()
    {
        eventcheck = manager.GetComponent<eventManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("help me god");
        if (other.CompareTag("Player"))
        {
            Debug.Log("jesus died for our sins");
            eventcheck.CheckTrigger(gameObject.GetHashCode());
        }
    }
}
