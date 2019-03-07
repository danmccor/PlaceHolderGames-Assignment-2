using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Stat Health;
    [SerializeField]
    private Stat Sanity;

    private void Awake()
    {
        Health.Initialize();
        Sanity.Initialize();
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Health.CurVal -= 1;
           
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            Sanity.CurVal -= 1;
        }
        
    }
}
