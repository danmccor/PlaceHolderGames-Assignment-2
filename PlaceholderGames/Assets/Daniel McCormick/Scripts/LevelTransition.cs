using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{

    public Transform TeleportPoint;
    public int BuildIndexToLoad;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        bool alreadyLoaded = false;
        for (int i = 0; i < SceneManager.sceneCount; ++i)
        {
            if (SceneManager.GetSceneAt(i).buildIndex == BuildIndexToLoad)
            {
                alreadyLoaded = true;
            }
        }

        if (alreadyLoaded == false)
        {
            SceneManager.LoadScene(BuildIndexToLoad, LoadSceneMode.Additive);
        }


        if (other.CompareTag("Player"))
        {
            StartCoroutine(player.GetComponent<playerControls>().TeleportPlayer(TeleportPoint.position));
        }
        if (other.CompareTag("AI"))
        {
            other.gameObject.GetComponent<NavMeshAgent>().Warp(TeleportPoint.position);
        }
    }
}
