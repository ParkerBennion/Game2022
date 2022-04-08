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
        if (ObjectHitData.rayInfo.collider.name == "1")
        {
            rightLaser.transform.localScale = new Vector3(1f, 0, 20);
        }
        if (ObjectHitData.rayInfo.collider.name == "RightBox")
        {
            leftLaser.transform.localScale = new Vector3(1f, 0, 20);
        }
        if (ObjectHitData.rayInfo.collider.name == "RearBox")
        {
            frontLaser.transform.localScale = new Vector3(1f, 0, 20);
        }
        if (ObjectHitData.rayInfo.collider.name == "FrontBox")
        {
            rearLaser.transform.localScale = new Vector3(1f, 0, 20);
        }
        else
        {
            rightLaser.transform.localScale = new Vector3(1f, 0, 2);
            leftLaser.transform.localScale = new Vector3(1f, 0, 4);
            rearLaser.transform.localScale = new Vector3(1f, 0, 6);
            frontLaser.transform.localScale = new Vector3(1f, 0, 8);
            Debug.Log(ObjectHitData.rayInfo.collider.name);
        }
    }
    //this doesnt worlk
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log(ObjectHitData.rayInfo.collider.name);
            TransmitLaser();
        }
    }
}
