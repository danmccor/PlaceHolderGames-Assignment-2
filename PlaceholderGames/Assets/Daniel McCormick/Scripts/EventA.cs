using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventA : MonoBehaviour
{

    public List<GameObject> doors = new List<GameObject>();
    public GameObject player;
    private float bloodTimers = 5f;
    private int currentBlood = 0;
    private float eventTimer = 25f;

    public GameObject bloodflow1;
    public GameObject bloodflow2;
    public GameObject bloodflow3;

    public GameObject bloodSurface;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        for (int i = 0; i < doors.Count; i++)
        {
            doors[i].GetComponent<openDoor>().CloseDoor();
            doors[i].GetComponent<openDoor>().DoorLocked(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (eventTimer > 0)
        {
            if (bloodTimers <= 0)
            {
                switch (currentBlood)
                {
                    case 0:
                        bloodflow1.SetActive(true);
                        currentBlood++;
                        bloodTimers = 5f;
                        break;
                    case 1:
                        bloodflow2.SetActive(true);
                        currentBlood++;
                        bloodTimers = 5f;
                        break;
                    case 2:
                        bloodflow3.SetActive(true);
                        currentBlood++;
                        bloodTimers = 5f;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                bloodTimers -= Time.deltaTime;
            }

            if (currentBlood == 0)
            {

            }
            else if (currentBlood == 1)
            {
                bloodSurface.transform.Translate(new Vector3(0, 0.01f, 0) * Time.deltaTime);
            }
            else if (currentBlood == 2)
            {
                bloodSurface.transform.Translate(new Vector3(0, 0.05f, 0) * Time.deltaTime);
            }
            else if (currentBlood == 3)
            {
                bloodSurface.transform.Translate(new Vector3(0, 0.09f, 0) * Time.deltaTime);
            }
            eventTimer -= Time.deltaTime;
        }
        else
        {
            
            for (int i = 0; i < doors.Count; i++)
            {
                doors[i].GetComponent<openDoor>().DoorLocked(false);
            }
            player.GetComponent<playerControls>().playerBlinking = true;
            this.gameObject.SetActive(false);
        }
    }

}
    

    

