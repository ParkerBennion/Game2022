using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeDestruction : MonoBehaviour
{
    public GameObject cube, cubeDamege1, cubeDamage2, cubeFrag1, cubeFrag2, cubeFrag3, cubeFrag4, cubeFrag5, cubeFrag6;
    public SO_BoolSwitcher laserBool;
    private WaitForSeconds suspensfullDelay = new WaitForSeconds(1);
    private Rigidbody[] frags;
    private Renderer[] colorsOfCubes;
    public Color obliskColor;
    public SO_ColorHolder laserColor;
    public SO_Color TileColor;
    
    private void Start()
    {
        frags = GetComponentsInChildren<Rigidbody>();
        colorsOfCubes = GetComponentsInChildren<Renderer>();
        
        setColor();
    }

    public void RunDestruction()
    {
        StartCoroutine(DestructCube(laserColor));
    }

    public void setColor()
    {
        obliskColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.7f, .7f);
        for (int i = 0; i < colorsOfCubes.Length; i++)
        {
            colorsOfCubes[i].material.color = obliskColor;
        }
    }

    IEnumerator DestructCube(SO_ColorHolder laserColor)
    {
        //compare tile color to oblisk color. then destroy oblisk
        if (laserBool && 
            laserColor.sOcolor.r >= .1f &&
            laserColor.sOcolor.r <= 244f)
            
            
        {
            cube.SetActive(false);
            yield return suspensfullDelay;
            cubeDamege1.SetActive(false);
            yield return suspensfullDelay;
            cubeDamage2.SetActive(false);
            yield return suspensfullDelay;
            Debug.Log(laserColor);

            for (int i = 0; i < frags.Length; i++)
            {
                frags[i].AddExplosionForce(1000,transform.position,500);
            }
                
        }
        Debug.Log("NOHIT");
    }

    public void resetOblisk()
    {
        //reset the oblisk to original position after destruction.
    }
}
