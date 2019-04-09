using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Text BoxToWriteIn;
    //give them a thing to say
    public string[] ThingToSay;
    //sound stuff
    public AudioClip[] Voice;
    public AudioSource source;
    //Tone of voice
    [Range(0.0f, 2.0f)]
    public float[] Pitch;
    [Range(0.0f, 2.0f)]
    public float[] volume;
    private int Lines;
    //make them say it
    [HideInInspector]
    public bool MakeTalk;
    //get rid of the text box
    [HideInInspector]
    public bool Spoken;//character has said their line
    public bool automated;//if automated will play as soon as object is enabled

    private bool talking;//stop coroutine repeating

    public float TalkSpeed; //rate at which letters appear on screen, the higher the slower

    private void Start()
    {
        MakeTalk = false;
        Spoken = false;
        talking = false;
        Lines = 0;
    }

    private void Update()
    {
        //press F and they say the thing, this is for testing change the MakeTalk bool within a script to make them say stuff
        if (Input.GetKeyDown(KeyCode.Space) && !Spoken || automated && !Spoken)
        {
            //set up for what's to be said
            if (Lines < ThingToSay.Length)
            {
                MakeTalk = true;
            }


        }
        //get rid of the subtitles, set up the next line
        else if (Input.GetKeyDown(KeyCode.Space) && Spoken || automated && Spoken)
        {
            MakeTalk = false;
            talking = false;
            Spoken = false;
            BoxToWriteIn.text = "";
            ++Lines;
        }
        if (MakeTalk == true && !talking)
        {
            //plays the sound
            source.pitch = Pitch[Lines];
            source.volume = volume[Lines];
            source.clip = Voice[Lines];
            source.Play();
            //start displaying the subtitles
            StartCoroutine(Talk());
        }
    }

    private IEnumerator Talk()
    {
        talking = true;
        //itterates through string reading out one character at a time to the text box *if there is no +1 the subtitles stop on the penultimate character*
        for (int i = 0; i < ThingToSay[Lines].Length + 1; i++)
        {
            BoxToWriteIn.text = ThingToSay[Lines].Substring(0, i);
            if (i == ThingToSay[Lines].Length)
                Spoken = true;
            yield return new WaitForSeconds(TalkSpeed);
        }

    }
}
