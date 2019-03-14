using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windScript : MonoBehaviour
{
    public float windForce = 0;
    public float minWindForce = 0;
    public float maxWindForce = 10;
    public float windPowerTimer = 1f;
    GameObject[] boxes;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        windForce = minWindForce;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(wind());

        boxes = GameObject.FindGameObjectsWithTag("boxes");
        foreach (GameObject obj in boxes)
        {

            //var rotation = Quaternion.AngleAxis(windForce, Vector3.forward);
            //Vector3 relativePos = new Vector3(transform.position.x, obj.transform.position.y, transform.position.z) - obj.transform.position;
            //Quaternion rotation = Quaternion.LookRotation(relativePos);
            //obj.transform.rotation = Quaternion.Slerp(obj.transform.rotation, rotation, Time.deltaTime * 2.0f);

            obj.GetComponent<Rigidbody>().AddForce((new Vector3(Random.Range(-360, 360), Random.Range(-45, 45), Random.Range(-360, 360))).normalized *windForce);

        }
    }

    IEnumerator wind()
    {
        windForce+=0.1f;
        windForce = Mathf.Clamp(windForce, minWindForce, maxWindForce);
        yield return new WaitForSeconds(windPowerTimer);
    }
}
