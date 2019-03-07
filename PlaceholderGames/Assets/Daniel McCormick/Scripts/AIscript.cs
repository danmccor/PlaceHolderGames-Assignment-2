using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIscript : MonoBehaviour
{
    public bool following = false;
    public bool idle = true;
    public bool fleeing = false;
    public bool exploring = false;
    public bool attacking = false;

    public enum States {following, idle, fleeing, exploring, attacking};


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (following)
        {

        }
        if (idle)
        {

        }
        if (fleeing)
        {


        }
        if (exploring)
        {

        }
        if (attacking)
        {

        }
    }
}
