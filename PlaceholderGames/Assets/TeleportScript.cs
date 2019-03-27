using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class TeleportScript : MonoBehaviour
{
    private bool teleportingPlayer;
    public Transform teleportPoint;
    private float teleTime = 2f; 
    public int buildLevel;
    private GameObject player; 
    // Start is called before the first frame update
    void Start()
    {
        teleportingPlayer = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (teleportingPlayer)
        {
            if(teleTime <= 0)
            {
                TeleportPlayer();
                teleTime = 2f;
            }
            else
            {
                teleTime -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("AI"))
        {
            bool alreadyLoaded = false;
            for (int i = 0; i < SceneManager.sceneCount; ++i)
            {
                if (SceneManager.GetSceneAt(i).buildIndex == buildLevel)
                {
                    alreadyLoaded = true;
                }
            }


            //Scene[] scene = SceneManager.GetAllScenes();
            if (alreadyLoaded == false)
            {
                SceneManager.LoadScene(buildLevel, LoadSceneMode.Additive);
            }
            if (other.gameObject.CompareTag("AI"))
            {
                other.gameObject.GetComponent<NavMeshAgent>().Warp(gameObject.transform.GetChild(0).transform.position);
            }
            else if (other.gameObject.CompareTag("Player"))
            {
                
                teleportingPlayer = true;
            }
        }
        
    }
    
    void TeleportPlayer()
    {
        Debug.Log(teleportPoint.gameObject.transform.position);
        player.gameObject.transform.position = teleportPoint.gameObject.transform.position;
        teleportingPlayer = false;
        player.gameObject.GetComponent<playerControls>().FlipPlayerMovement(true);
    }
}
