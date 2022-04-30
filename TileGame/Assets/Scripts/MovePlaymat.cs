using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MovePlaymat : MonoBehaviour
{
    private float current=20, target =55, startTime;
    public bool go;
    public float duration = 2;
    private WaitForSeconds wfs;
    public GameObject levelSpawner;

    public GameObject triggerVol;
    //public GameObject platform;
    
    public void MoveToNextPose()
    {
        startTime = Time.time;
        go = true;
        wfs = new WaitForSeconds(duration);
        StartCoroutine(MoveToNextPoseCo());
        triggerVol.SetActive(false);
    }

    private void Update()
    {
        if (go)
        {
            
            float t = (Time.time - startTime) / duration;

            transform.position = new Vector3(0, -1, Mathf.SmoothStep(current, target, t));
            
        }
    }
    
    
    

    private IEnumerator MoveToNextPoseCo()
    {
        // while (go)
        // {
        //     //Debug.Log("to nextPos");
        //     //float t = (Time.time - startTime) / duration;
        //
        //     //.position = new Vector3(0, -1, Mathf.SmoothStep(current, target, t));
        //     
        //     yield return wfs;
        //     go = false;
        // }

        yield return wfs;
        go = false;
        current = transform.position.z;
        target = current + 35;
        triggerVol.SetActive(true);
        levelSpawner.SetActive(true);
    }
}
