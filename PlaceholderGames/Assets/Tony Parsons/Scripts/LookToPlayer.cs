//https://www.youtube.com/watch?v=-_k8Ob7ElUo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script will make the object it is placed on
//rotate towards an object passed into it
public class LookToPlayer : MonoBehaviour
{

    public float rotateSpeed;
    public GameObject Player; //this does not neccessarily have to be the player

    Vector3 LastPos;//for storing player position
    Quaternion LookAt;//for storing the position to rotate this object towards

    private void Start()
    {
        LastPos = Vector3.zero;
    }

    private void Update()
    {
        //if the players' position changes
        if(LastPos != Player.transform.position)
        {
            //record the change and set it as the new point to rotate towards
            LastPos = Player.transform.position - gameObject.transform.position;
            LookAt = Quaternion.LookRotation(LastPos);
        }
    }

    private void FixedUpdate()
    {

        //if this objects rotation is not the one intended
        if (transform.rotation != LookAt) //rotate the object (This objects totation, destination, Speed)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, LookAt, rotateSpeed * Time.deltaTime);
    }
}
