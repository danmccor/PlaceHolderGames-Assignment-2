using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour


{
    [SerializeField]
    private float fillAmt;
    [SerializeField]
    private Image cont;

    public float MaxValue { get; set; }

    public float Value
    {
        set
        {
            fillAmt = Map(value,0,MaxValue,0,1);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ChangeBar();
    }


    private void ChangeBar()
    {
        if (fillAmt != cont.fillAmount)
        {
            cont.fillAmount = fillAmt;
        }
    }

    private float Map (float value, float aMin, float aMax, float bMin, float bMax)
    {
        return (value - aMin) * (bMax - bMin) / (aMax - aMin) + bMin;
        // (80 - 0) * (1 - 0) / (100 - 0) + 0
        // 80 * 1 / 100 = 0.8 (< this is fill amount translation)
    }
}
