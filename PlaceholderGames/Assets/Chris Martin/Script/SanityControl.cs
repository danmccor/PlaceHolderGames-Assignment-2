using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SanityControl : MonoBehaviour
{

    public GameObject player;
    int layermaskSanity = 1 << 14;
    int rayDistance = 10;
    Ray ray;
    public GameObject targetObject;
    float timer = 2;
    Stat playerStat;

    // Start is called before the first frame update
    void Start()
    {
       playerStat = player.GetComponent<Player>().Sanity;
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        ray.origin = transform.position;
        ray.direction = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(ray, out hit, rayDistance, layermaskSanity, QueryTriggerInteraction.UseGlobal))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            targetObject = hit.collider.gameObject;


            if (timer <= 0)
            {
                playerStat.CurVal -= 1;
                timer = 2;

            }
            else
            {
                timer -= Time.deltaTime;
            }
            

            Debug.Log(timer);
        }

    }
}
