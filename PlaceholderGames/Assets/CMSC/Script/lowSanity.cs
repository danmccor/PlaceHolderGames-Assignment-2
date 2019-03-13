using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lowSanity : MonoBehaviour
{
    public GameObject player;
    public int i;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Player>().Sanity.CurVal <= 2)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                int random = Random.Range(0, 2);

                if (random == 1)
                {
                    transform.GetChild(i).GetChild(3).GetComponent<Light>().enabled = !transform.GetChild(i).GetChild(3).GetComponent<Light>().enabled;
                }
            }
        }
        if (player.GetComponent<Player>().Sanity.CurVal > 2)
        {
            for (int i = 0; i < transform.childCount; i++)
            {


                transform.GetChild(i).GetChild(3).GetComponent<Light>().enabled = true;
                
            }
        }

    }
}
