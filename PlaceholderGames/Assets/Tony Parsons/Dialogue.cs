using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Text BoxToWriteIn;
    //give them a thing to say
    public string ThingToSay;
    //make them say it
    [HideInInspector]
    public bool MakeTalk;
    //get rid of the text box
    [HideInInspector]
    public bool Spoken;//character has said their line

    private bool talking;//stop coroutine repeating

    public float TalkSpeed; //rate at which letters appear on screen

    private void Start()
    {
        MakeTalk = false;
        Spoken = false;
        talking = false;
    }

    private void Update()
    {
        //press F and they say the thing, this is for testing change the MakeTalk bool within a script to make them say stuff
        if(Input.GetKeyDown(KeyCode.F) && !Spoken)
        {
            MakeTalk = true;
        }
        else if(Input.GetKeyDown(KeyCode.F) && Spoken)
        {
            MakeTalk = false;
            talking = false;
            Spoken = false;
            BoxToWriteIn.text = "";
        }
        if(MakeTalk == true && !talking)
        {
            StartCoroutine(Talk());
        }
    }

    private IEnumerator Talk()
    {
        talking = true;
        //itterates through string reading out one character at a time to the text box
        for (int i = 0; i < ThingToSay.Length + 1; i++)
        {
            BoxToWriteIn.text = ThingToSay.Substring(0, i);
            if (i == ThingToSay.Length)
                Spoken = true;
            yield return new WaitForSeconds(TalkSpeed);
        }
        
    }
}
