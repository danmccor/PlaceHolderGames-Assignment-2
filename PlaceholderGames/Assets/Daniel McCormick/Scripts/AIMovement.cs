using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    public Transform goal;
    private NavMeshAgent agent;
    private GameObject lastDoor;
    public float doorTimer = 2f;
    public bool openedDoor = false;

    // Start is called before the first frame update
    void Start()
    {
         agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (openedDoor)
        {
            if(doorTimer <= 0)
            {
                lastDoor.GetComponent<openDoor>().CloseDoor();
                openedDoor = false;
                doorTimer = 0.5f;
                lastDoor = null;
            }
            else
            {
                doorTimer -= Time.deltaTime;
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Touching Something");
        if(col.gameObject.CompareTag("Door"))
        {
            Debug.Log("Touching Door");
            col.gameObject.GetComponent<openDoor>().OpenDoor();
            lastDoor = col.gameObject;
            openedDoor = true;
        }
    }
}
