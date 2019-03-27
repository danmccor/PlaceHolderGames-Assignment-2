using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This is the script for the bath event
public class Underwater : MonoBehaviour
{
    //water stuff
    public GameObject WaterSurface;
    public GameObject WaterSurfaceBlood;
    public GameObject WaterPanel; //the panel to activated/deactivated
    public ParticleSystem BloodDrops;
    //bath stuff
    public Renderer Bath;
    public Material[] BathMats;
    //Player character
    public GameObject Plae;
    //cameras
    public GameObject GameCam;//main camera
    //public Transform OrientateGameCam; test scene variable
    public Transform ParticlePosition; //Places the particle effect above the main camera
    public GameObject CutsceneCam;//Camera that has the cutscene of the player going into the bath
    //Time Oriented stuff
    private bool EndEvent;
    private bool inBath;
    private float delay;
    private float countdown;

    private void Start()
    {
        //set countdown
        delay = 5.0f;
        countdown = delay;
        //ensure bools are correct
        inBath = false;
        EndEvent = false;
        //swap camera
        Plae.SetActive(false);
        CutsceneCam.SetActive(true);
    }



    private void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0)
        {
            if (!inBath)
            {
                //Entering water visuals
                WaterPanel.SetActive(true);
                WaterSurface.SetActive(false);
                Bath.sharedMaterial = BathMats[1]; //change bath material
                //setup next phase of cutscene
                inBath = true;
                countdown = delay;
            }
            else if(inBath && !EndEvent)
            {
                //change water surface to red
                WaterSurfaceBlood.SetActive(true);
                //play particle effect
                BloodDrops.gameObject.SetActive(true);
                //change bath material back
                Bath.sharedMaterial = BathMats[0];
                //setup next phase of cutscene
                EndEvent = true;
                countdown = delay;
            }
            else
            {
                //This is for my test scene, it doesn't do anything in the main project
                //Orientate main camera 
                //Plae.transform.LookAt(OrientateGameCam);
                //FindObjectOfType<Movement_test_script>().Moving = true;
                //FindObjectOfType<Movement_test_script>().Moving = false;
                //-----------------------------------------------------------------
                //switch off cutscene cam and re-activate player
                CutsceneCam.SetActive(false);
                Plae.SetActive(true);
                //change position of particle effect
                BloodDrops.transform.parent = Plae.transform;
                BloodDrops.transform.position =  ParticlePosition.transform.position;

                this.gameObject.SetActive(false);
            }
        }
    }
}