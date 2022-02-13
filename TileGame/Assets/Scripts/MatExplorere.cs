using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatExplorere : MonoBehaviour

{
    public Material newMat;
    public float sec;

    private void Start()
    {
        StartCoroutine(Change());
    }
    
    IEnumerator Change()
    {
        yield return new WaitForSeconds(2);

        newMat.color = new Color(.7f,0,1,.5f);
        Debug.Log("color Change");
    }
}
