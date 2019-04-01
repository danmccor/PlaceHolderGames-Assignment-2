using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCorder_Event : MonoBehaviour
{
    //Camcorder
    public GameObject CamCorder;
    public GameObject CamCorder_Cutscene;
    //Camera - As in player viewports
    private CharacterController Plae;
    public Camera CutSceneCam;
    public Transform restoreCamPosition;//put camera here when it is re-activated
    //time stuff
    private float delay = 5.0f; //time animation takes
    private float countdown;


    //swap camcorder for one with animation
    private void Start()
    {
        //deactivate player character and activate the cutscene camera
        Plae = FindObjectOfType<CharacterController>();
        Plae.gameObject.SetActive(false);
        CamCorder.SetActive(false);
        CamCorder_Cutscene.SetActive(true);
        countdown = delay;
    }

    private void Update()
    {
        countdown -= Time.deltaTime;
        //after 5 seconds
        if(countdown <= 0)
        {
            //shut off cutscene cam, re-activate player
            CamCorder_Cutscene.SetActive(false);
            Plae.transform.position = restoreCamPosition.position;
            Plae.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

}
