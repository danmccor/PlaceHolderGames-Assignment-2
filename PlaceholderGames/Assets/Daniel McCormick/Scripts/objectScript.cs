using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectScript : MonoBehaviour
{
    public float layerTimer = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.layer == 0)
        {
            if(layerTimer >= 0)
            {
                layerTimer -= Time.deltaTime;
            }
            else
            {
                gameObject.layer = 9;
                layerTimer = 5f;
            }



        }
    }


}
