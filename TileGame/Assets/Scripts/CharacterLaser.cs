using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLaser : MonoBehaviour
{
    public SO_CastDat ObjectHitData;

    public GameObject leftLaser;
    public GameObject rightLaser;
    public GameObject rearLaser;
    public GameObject frontLaser;
    // Start is called before the first frame update
    
    public void TransmitLaser()
    {
        if (ObjectHitData.rayInfo.collider.name.Equals("1"))
        {
            rightLaser.transform.localScale = new Vector3(1f, 0, 20);
        }
        if (ObjectHitData.rayInfo.collider.name.Equals("RightBox"))
        {
            leftLaser.transform.localScale = new Vector3(1f, 0, 20);
        }
        if (ObjectHitData.rayInfo.collider.name == "RearBox")
        {
            frontLaser.transform.localScale = new Vector3(1f, 0, 20);
        }
        if (ObjectHitData.rayInfo.ToString() == "FrontBox")
        {
            rearLaser.transform.localScale = new Vector3(1f, 0, 20);
        }
        if (ObjectHitData.rayInfo.collider.name.Equals("BackDrop"))
        {
            rightLaser.transform.localScale = new Vector3(1f, 0, 0);
            leftLaser.transform.localScale = new Vector3(1f, 0, 0);
            rearLaser.transform.localScale = new Vector3(1f, 0, 0);
            frontLaser.transform.localScale = new Vector3(1f, 0, 0);
            Debug.Log(ObjectHitData.rayInfo.collider.name);
        }
    }
    //only one laser is allowed to hit at a time. this creates issues but will have to be put off for later date
    // need to make lasers activate off of call instead of manually activating


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log(ObjectHitData.rayInfo.collider.name);
            TransmitLaser();
        }
    }
}
