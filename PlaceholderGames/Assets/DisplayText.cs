using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{

    public Text text;
    public bool displayingText = false;
    public float textTimer = 1f;
    // Start is called before the first frame update
    void Start()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (displayingText)
        {
            if (textTimer >= 0)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, 1-textTimer);
                textTimer -= Time.deltaTime;
            }
            else
            {
                displayingText = false;
                textTimer = 1f;
            }
        }
        if (!displayingText && text.color.a > 0)
        {
            if(textTimer >= 0)
            {
                textTimer -= Time.deltaTime;
                text.color = new Color(text.color.r, text.color.g, text.color.b, textTimer);
            }
            else
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
                textTimer = 1f;
            }
        }
    }

    public void displayText(string textToDisplay)
    {
        text.text = textToDisplay;
        displayingText = true;

    }
}
