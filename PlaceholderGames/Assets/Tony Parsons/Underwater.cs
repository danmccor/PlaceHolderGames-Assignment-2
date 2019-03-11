using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//THIS SCRIPT IS FOR THE BATHWATER, IT PUTS UP A BLUE PANEL 
//WHEN THE CAMERA COLLIDES/ENTERS THE OBJECT
//AND TURNS IT OFF WHEN THE CAMERA EXITS THE OBJECT
public class Underwater : MonoBehaviour
{
    public GameObject bluePanel; //the panel to activated/deactivated
    public ParticleSystem waterDrops;

    private bool Wet;
    private float delay;
    private float countdown;

    private void Start()
    {
        delay = 5;
        countdown = delay;
        Wet = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        bluePanel.SetActive(true);
    }

    //camera exits bath, switch off panel play particle effect for 3 seconds
    private void OnTriggerExit(Collider other)
    {
        //switch off panel
        bluePanel.SetActive(false);

        //if the particle effect game object is off, switch it on
        if (waterDrops.gameObject.activeSelf == false)
            waterDrops.gameObject.SetActive(true);
        //play the particle animation
        waterDrops.Play();
        Wet = true;
    }

    private void Update()
    {
        if(Wet)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                waterDrops.gameObject.SetActive(false);
                Wet = false;
                countdown = delay;
            }
        }
    }
}
