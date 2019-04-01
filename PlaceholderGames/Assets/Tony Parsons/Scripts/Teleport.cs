using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject Player;
    //Portrait Morphing
    public GameObject Normal_Portrait;//portrait that changes
    public GameObject Morphing_Portrait;//portrait with changing animation
    //Teleporting
    public Transform Teleport_Spot;
    private bool has_Teleported;
    //Time Stuff
    private float delay = 5.0f;
    private float countdown;

    private void Start()
    {
        Normal_Portrait.SetActive(false);
        countdown = delay;
        has_Teleported = false;
    }

    private void Update()
    {
        
        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            //move player to transform, reset countdown, set bool == true
            if (!has_Teleported)
            {
                Player.transform.position = Teleport_Spot.position;
                countdown = delay;
                has_Teleported = true;
            }
            //Change portrait back and de-activate this object
            else
            {
                Normal_Portrait.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }
    }
}
