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
    private LineRenderer lineColorLeft;
    private LineRenderer lineColorRight;
    private LineRenderer lineColorRear;
    private LineRenderer lineColorFront;
    private LineRenderer masterColor;
    private Vector3 zero;
    public SO_Color cubeColor;
    
    
    // Start is called before the first frame update
    private void Start()
    {
        zero = new Vector3(0, 0, 0);
        lineColorLeft = leftLaser.GetComponent<LineRenderer>();
        lineColorRight = rightLaser.GetComponent<LineRenderer>();
        lineColorRear = rearLaser.GetComponent<LineRenderer>();
        lineColorFront = frontLaser.GetComponent<LineRenderer>();
        
        // float alpha = 1.0f;
        // Gradient gradient = new Gradient();
        // gradient.SetKeys(
        //     new GradientColorKey[] { new GradientColorKey(cubeColor.passedColor, 0.0f), new GradientColorKey(Color.white, 1.0f) },
        //     new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(0, 1.0f) }
        // );
        // lineColorFront.colorGradient = gradient;
    }

    public void TransmitLaser()
    {
        if (ObjectHitData.rayInfo.collider.name.Equals("LeftBox"))
        {
            //rightLaser.transform.localScale = new Vector3(1f, 0, 20);
            ProjectLaserFromPlayer(rightLaser);
            //lineColorRight.colorGradient = masterColor.colorGradient;
            float alpha = 1.0f;
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(cubeColor.passedColor, 0.0f), new GradientColorKey(cubeColor.passedColor, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(0, 1.0f) }
            );
            lineColorRight.colorGradient = gradient;
            
        }
        if (ObjectHitData.rayInfo.collider.name.Equals("RightBox"))
        {
            //leftLaser.transform.localScale = new Vector3(1f, 0, 20);
            ProjectLaserFromPlayer(leftLaser);
            //lineColorLeft.colorGradient = masterColor.colorGradient;
            float alpha = 1.0f;
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(cubeColor.passedColor, 0.0f), new GradientColorKey(cubeColor.passedColor, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.3f), new GradientAlphaKey(0, 1.0f) }
            );
            lineColorLeft.colorGradient = gradient;

        }
        if (ObjectHitData.rayInfo.collider.name == "RearBox")
        {
            //frontLaser.transform.localScale = new Vector3(1f, 0, 20);
            ProjectLaserFromPlayer(frontLaser);
            //lineColorFront.colorGradient = masterColor.colorGradient;
            float alpha = 1.0f;
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(cubeColor.passedColor, 0.0f), new GradientColorKey(cubeColor.passedColor, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(0, 1.0f) }
            );
            lineColorFront.colorGradient = gradient;

        }
        if (ObjectHitData.rayInfo.collider.name == "FrontBox")
        {
            //rearLaser.transform.localScale = new Vector3(1f, 0, 20);
            ProjectLaserFromPlayer(rearLaser);
            //lineColorRear.colorGradient = masterColor.colorGradient;
            float alpha = 1.0f;
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(cubeColor.passedColor, 0.0f), new GradientColorKey(cubeColor.passedColor, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(0, 1.0f) }
            );
            lineColorRear.colorGradient = gradient;

        }
        if (ObjectHitData.rayInfo.collider.name.Equals("BackDrop"))
        {
            rightLaser.transform.localScale = zero;
            leftLaser.transform.localScale = zero;
            rearLaser.transform.localScale = zero;
            frontLaser.transform.localScale = zero;
            
        }
        if (ObjectHitData.rayInfo.collider.name.Equals("BackDrop2"))
        {
            rightLaser.transform.localScale = zero;
            leftLaser.transform.localScale = zero;
            rearLaser.transform.localScale = zero;
            frontLaser.transform.localScale = zero;
            
        }
    }
    //only one laser is allowed to hit at a time. this creates issues but will have to be put off for later date
    // need to make lasers activate off of call instead of manually activating
    void ProjectLaserFromPlayer(GameObject laserHit)
    {
        RaycastHit hit;
        int layerMask = 1 << 8;
        if (Physics.Raycast(laserHit.transform.position,laserHit.transform.TransformDirection(Vector3.forward),out hit,Mathf.Infinity,layerMask))
        {
            //Debug.Log(hit.rayInfo.collider.name);
            laserHit.transform.localScale = new Vector3(1f, 0, hit.distance*2f);

        }
        else
        {
            laserHit.transform.localScale = new Vector3(1f, 0, 100);
        }
        Debug.Log(laserHit.transform.rotation);
    }

    public void resetLaser()
    {
        rightLaser.transform.localScale = zero;
        leftLaser.transform.localScale = zero;
        rearLaser.transform.localScale = zero;
        frontLaser.transform.localScale = zero;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log(ObjectHitData.rayInfo.collider.name);
            TransmitLaser();
        }
    }
    
    /*lr = GetComponent<LineRenderer>();
    lr.material = new Material(Shader.Find("Sprites/Default"));

    // Set some positions
    Vector3[] positions = new Vector3[3];
    positions[0] = new Vector3(-2.0f, -2.0f, 0.0f);
    positions[1] = new Vector3(0.0f,  2.0f, 0.0f);
    positions[2] = new Vector3(2.0f, -2.0f, 0.0f);
    lr.positionCount = positions.Length;
    lr.SetPositions(positions);

    // A simple 2 color gradient with a fixed alpha of 1.0f.
    float alpha = 1.0f;
    Gradient gradient = new Gradient();
    gradient.SetKeys(
    new GradientColorKey[] { new GradientColorKey(Color.green, 0.0f), new GradientColorKey(Color.red, 1.0f) },
    new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
    );
    lr.colorGradient = gradient;*/
}
