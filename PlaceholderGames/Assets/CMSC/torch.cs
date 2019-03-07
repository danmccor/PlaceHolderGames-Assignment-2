using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            this.GetComponent<Light>().enabled = !this.GetComponent<Light>().enabled;
            
            
        }
       /* if (Input.GetKeyDown(KeyCode.O))
        {
            this.GetComponent<Light>().enabled = false;
        }
        */
    }
}
