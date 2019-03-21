﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public Stat Health;
    [SerializeField]
    public Stat Sanity;

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
        if (Input.GetKeyDown(KeyCode.K))
        {

            Sanity.CurVal += 1;

        }
    }
}
