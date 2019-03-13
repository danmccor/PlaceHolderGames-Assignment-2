using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventA : MonoBehaviour
{
    public GameObject player;
    private float bloodTimers = 5f;
    private int currentBlood = 0;
    private float eventTimer = 25f;

    public GameObject bloodflow1;
    public GameObject bloodflow2;
    public GameObject bloodflow3;

    public GameObject bloodSurface;

    public GameObject door1;
    public GameObject door2;
    // Start is called before the first frame update
    void Start()
    {
        door1.GetComponent<openDoor>().CloseDoor();
        door2.GetComponent<openDoor>().CloseDoor();

        door1.GetComponent<openDoor>().DoorLocked(true);
        door2.GetComponent<openDoor>().DoorLocked(true);
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
            this.gameObject.SetActive(false);
        }
        }

    }
    

    

