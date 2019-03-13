using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    public Transform goal;
    private NavMeshAgent agent;
    private GameObject lastDoor;
    public Transform player;

    public bool attackingPlayer = false;
    public bool followingPlayer = false;
    public float doorTimer = 0.3f;
    public float browsingTimer = 5f;
    public float collisionTimer = 2f;

    public float stoppingDistance = 5f;
    public bool openedDoor = false;


    int layermask = 1 << 9;
    Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
       //agent.destination = goal.position;
        //agent.stoppingDistance = stoppingDistance;
    }

    // Update is called once per frame
    void Update()
    {
        //if (openedDoor)
        //{
        //    if(doorTimer <= 0)
        //    {
        //        lastDoor.GetComponent<openDoor>().CloseDoor();
        //        openedDoor = false;
        //        doorTimer = 0.3f;
        //        lastDoor = null;
        //    }
        //    else
        //    {
        //        doorTimer -= Time.deltaTime;
        //    }
        //}
        if (!followingPlayer && !attackingPlayer) {
            agent.stoppingDistance = 0.2f;
            if (agent.remainingDistance < 1)
            {
                if (browsingTimer >= 0)
                {
                    browsingTimer -= Time.deltaTime;
                }
                else
                {
                    RaycastHit hit;
                    ray.origin = transform.position;
                    ray.direction = transform.TransformDirection(Vector3.forward);
                    for (int i = 0; i < 100; i++)
                    {
                        if (Physics.SphereCast(ray, i, out hit, Mathf.Infinity, layermask, QueryTriggerInteraction.UseGlobal))
                        {
                            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
                            if (hit.transform.gameObject.name != goal.name)
                            {
                                goal = hit.transform;
                                agent.destination = goal.position;
                                break;
                            }
                        }
                        else
                        {
                            agent.destination = WanderingNavAI(transform.position, 50, -1);
                        }
                    }
                    browsingTimer = 5f;
                }
            }
        }
        else
        {
            if (player == null)
            {
                followingPlayer = false;
            }
            else
            {
                agent.destination = player.transform.position;
            }
        }

    }

    Vector3 WanderingNavAI(Vector3 origin, float dist, int layermask)
    {
        Vector3 direction = Random.insideUnitSphere * dist;
        direction += origin;
        NavMeshHit navHit;

        NavMesh.SamplePosition(direction, out navHit, dist, layermask);

        return navHit.position;
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Touching Something");
        if(col.gameObject.CompareTag("Door"))
        {
            Debug.Log("Touching Door");
            col.gameObject.GetComponent<openDoor>().OpenDoor();
            col.gameObject.GetComponent<openDoor>().CloseDoor();
            //lastDoor = col.gameObject;
            //openedDoor = true;
        }
        
    }
    void OnControllerColliderHit(ControllerColliderHit col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Player>().Health.CurVal -= 1;

        }
    }

    public void FollowPlayer()
    {
        followingPlayer = true;
        agent.stoppingDistance = stoppingDistance;
    }

    public void ChangeLayer()
    {
        this.gameObject.layer = 10;
        StartCoroutine(resetCollisionLayer());
    }

    IEnumerator resetCollisionLayer()
    {
        yield return new WaitForSeconds(2f);
        gameObject.layer = 0;
    }
}
