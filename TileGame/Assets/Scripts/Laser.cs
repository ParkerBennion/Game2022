using System;
using System.Collections;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public SO_CastDat hit;
    public SO_Variables waitTimer;
    public WaitForSeconds waiting;
    private WaitForSeconds spacerTime = new WaitForSeconds(.02f);
    public bool allowTimer = true;
    public GameObject lineRendr;
    public SO_CallAction callRayHit;
    public SO_BoolSwitcher hitPlayer;
    
    // private void Update()
    // {
    //     int layerMask2 = 1 << 8;
    //     Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward)*1000,Color.red);
    //     if (Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hit.rayInfo,Mathf.Infinity,layerMask2))
    //     {
    //         
    //         Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward)*hit.rayInfo.distance,Color.cyan);
    //     }
    // }

    private void Awake()
    {
        waiting = new WaitForSeconds(waitTimer.floatVar);
    }

    public IEnumerator Waiter2()
    {
        yield return waiting;
        yield return spacerTime;
        CastRay();
        allowTimer = true;
    }

    public void Waiter1()
    {
        if (allowTimer == true)
        {
            StartCoroutine(Waiter2());
            allowTimer = false;
        }
        

    }

    public void CastRay()
    {
        
        int layerMask = 1 << 8;
        if (Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hit.rayInfo,Mathf.Infinity,layerMask))
        {
            //Debug.Log(hit.rayInfo.collider.name);
            lineRendr.transform.localScale = new Vector3(1f, 0, hit.rayInfo.distance);
            callRayHit.CallAction();
            if (hit.rayInfo.collider.name == "RearBox")
            {
                hitPlayer.specialBool = true;
            }
            else
            {
                hitPlayer.specialBool = false;
                Debug.Log("boolFalse");
            }
        }
        else
        {
            lineRendr.transform.localScale = new Vector3(1f, 0, 150);
        }
    }
}
