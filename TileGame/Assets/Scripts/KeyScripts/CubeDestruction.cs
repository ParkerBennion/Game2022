using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeDestruction : MonoBehaviour
{
    public GameObject cube, cubeDamege1, cubeDamage2, cubeFrag1, cubeFrag2, cubeFrag3, cubeFrag4, cubeFrag5, cubeFrag6, tile;
    public SO_BoolSwitcher laserBool;
    private WaitForSeconds suspensfullDelay = new WaitForSeconds(.5f);
    private WaitForSeconds ReconstructDelay = new WaitForSeconds(1.5f);
    private Rigidbody[] frags;
    private Renderer[] colorsOfCubes;
    public Color obliskColor;
    public SO_ColorHolder laserColor;
    public SO_Color TileColor;
    public float allowence =.25f;
    WaitForSeconds delay = new WaitForSeconds(.3f);
    WaitForSeconds fragDelay = new WaitForSeconds(3f);
    public SO_PowerCounter totalScore;
    public SO_CallAction destroyCubesForScore;
    private bool isDestructed = false;
    public SO_Variables addPointsToZero, generatePoints, shufflePoints, changePoints;

    public GameObject setpingTile;
    //private Vector3 origin;

    private void Awake()
    {
         totalScore.powerUpCubes = 0;
         totalScore.powerUpCubes1 = 0;
         totalScore.powerUpCubes2 = 0;
         generatePoints.intVar = 0;
         shufflePoints.intVar = 0;
         changePoints.intVar = 0;

    }

    private void Start()
    {
        
        frags = GetComponentsInChildren<Rigidbody>();
        colorsOfCubes = GetComponentsInChildren<Renderer>();
        //origin = new Vector3(0, 0, 0);
        setColor();
        
        
    }

    public void RunDestruction()
    {
        if (!isDestructed)
        {
            StartCoroutine(DestructCube(laserColor));
        }
        
    }

    public void setColor()
    {
        obliskColor = Random.ColorHSV(.0f, 1f, .2f, 1f, .4f, .9f);
        for (int i = 0; i < colorsOfCubes.Length; i++)
        {
            colorsOfCubes[i].material.color = obliskColor;
        }

        if (obliskColor.r < .2f || obliskColor.g < .2f ||  obliskColor.b < .2f )
        {
            setColor();
            //Debug.Log("refactoring Up");
        }
        if (obliskColor.r > .77f || obliskColor.g > .77f ||  obliskColor.b > .77f )
        {
            setColor();
            //Debug.Log("refactoring Down");
        }
    }
    
    IEnumerator DestructCube(SO_ColorHolder laserColor)
    {
        
        // Debug.Log(obliskColor.r + "r");
        // Debug.Log(obliskColor.g + "g");
        // Debug.Log(obliskColor.b + "b");
        //
        // Debug.Log(TileColor.thisTilesColor.r + "r t");
        // Debug.Log(TileColor.thisTilesColor.g + "g t");
        // Debug.Log(TileColor.thisTilesColor.b + "b t");

        
        yield return delay;

        if (TileColor.thisTilesColor.r <= (obliskColor.r +allowence) && TileColor.thisTilesColor.r >= (obliskColor.r -allowence) &&
            TileColor.thisTilesColor.g <= (obliskColor.g +allowence) && TileColor.thisTilesColor.g >= (obliskColor.g -allowence) &&
            TileColor.thisTilesColor.b <= (obliskColor.b +allowence )&& TileColor.thisTilesColor.b >= (obliskColor.b -allowence))
        {
            isDestructed = true;
            //jjj
            destroyCubesForScore.CallAction();
            totalScore.AddCubes();
            //jjj
            
            
            cube.SetActive(false);
            yield return suspensfullDelay;
            cubeDamege1.SetActive(false);
            yield return suspensfullDelay;
            cubeDamage2.SetActive(false);
            yield return suspensfullDelay;

            for (int i = 0; i < frags.Length; i++)
            {
                frags[i].AddExplosionForce(1000,transform.position,500);
            }
            setpingTile.SetActive(true);
            yield return fragDelay;
            for (int i = 0; i < frags.Length; i++)
            {
                frags[i].velocity = Vector3.zero;
                frags[i].angularVelocity = Vector3.zero;
            }
        }
    }

    public void activateResetOblisk()
    {
        StartCoroutine(ResetOblisk());
    }
    IEnumerator ResetOblisk()
    {
        addPointsToZero.intVar = 0;
        yield return ReconstructDelay;
        cubeDamage2.SetActive(true);
        setColor();
        yield return suspensfullDelay;
        cubeDamege1.SetActive(true);
        yield return suspensfullDelay;
        cube.SetActive(true);
        yield return suspensfullDelay;
        yield return ReconstructDelay;
        yield return ReconstructDelay;
        for (int i = 0; i < frags.Length; i++)
        {
            frags[i].angularVelocity = Vector3.zero;
            frags[i].velocity = Vector3.zero;
            frags[i].transform.SetPositionAndRotation(transform.position,new Quaternion(0,0,0,0));
        }
        
        isDestructed = false;
    }

    public void InstancePathway()
    {
        //instaciate
    }

    public void ReactivateLevelSpawer()
    {
        
    }
    
    
}
