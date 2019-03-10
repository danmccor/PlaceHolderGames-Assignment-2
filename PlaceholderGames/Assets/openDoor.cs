using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    private bool opening = false;
    private bool opened = false;
    private bool closing = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (opening)
        {
            Debug.Log("Opening Door");
            transform.GetChild(0).transform.Rotate(new Vector3(0, 90) * Time.deltaTime) ;
            transform.GetChild(1).transform.Rotate(new Vector3(0, -90) * Time.deltaTime);
        }
        if(transform.GetChild(0).transform.localEulerAngles.y >= 90) {
            opening = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            opened = true;
        }

        if (closing && !opening)
        {
            Debug.Log("Closing Door");
            transform.GetChild(0).transform.Rotate(new Vector3(0, -90) * Time.deltaTime);
            transform.GetChild(1).transform.Rotate(new Vector3(0, 90) * Time.deltaTime);
        }
        if (transform.GetChild(0).transform.localEulerAngles.y <= 2 && !opening)
        {
            
            closing = false;
            gameObject.GetComponent<BoxCollider>().enabled = true;
            opened = false;
        }
    }


    public void OpenDoor()
    {
        if (!opened)
        {
            opening = true;
        }

    }
    public void CloseDoor()
    {
        closing = true;
    }

    

}
