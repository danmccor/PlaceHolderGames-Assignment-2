using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shatterScript : MonoBehaviour
{
    public bool selfShatter;
    public GameObject shattered;
    float lastMagnitude;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (!selfShatter)
        {
            if (col.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 3)
            {
                GameObject.Instantiate(shattered, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }

        if (selfShatter)
        {
            if (lastMagnitude > 10 && gameObject.GetComponent<Rigidbody>().velocity.magnitude < 4)
            {
                GameObject.Instantiate(shattered, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            lastMagnitude = gameObject.GetComponent<Rigidbody>().velocity.magnitude;
        }

        
    }
}
