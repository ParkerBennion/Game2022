using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MatExplorere : MonoBehaviour

{
    
    public Material newMat;
    public Vector4 colorCode;
    private Color codedColor;
    private MeshRenderer rndr;

    private void Start()
    {
        codedColor.r = colorCode.x;
        codedColor.g = colorCode.y;
        codedColor.b = colorCode.z;
        codedColor.a = colorCode.w;
        MeshRenderer rndr = GetComponent<MeshRenderer>();
        rndr.material.color = codedColor;
        
        //manually sets a color
    }


    public void ColorChange()
    {
        newMat.color = codedColor;
        Debug.Log("color Change");
        
        //applies color
    }

    private void OnTriggerEnter(Collider other)
    {
        ColorChange();
        Debug.Log("Collision Made");
        Destroy(gameObject);
        
        //activates scripts
    }

    public void SetRandom()
    {
        MeshRenderer thisRndr = GetComponent<MeshRenderer>();

        Material randomMaterial;
        (randomMaterial = thisRndr.material).color = Random.ColorHSV(0f,1f,0f,1f,0f,1f,0f,1f);
        codedColor = randomMaterial.color;
        
        //goes crazy
    }
}
