using System;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private void Update()
    {
        int layerMask = 1 << 8;

        RaycastHit hit;
        if (Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hit,Mathf.Infinity,layerMask))
        {
            Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward)*hit.distance,Color.cyan);
            Debug.Log("did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward)*1000,Color.red);
            Debug.Log("did not hit");
        }
    }
}
