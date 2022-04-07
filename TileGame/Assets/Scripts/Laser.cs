using System;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public SO_CastDat hit;
    private void Update()
    {
        
            Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward)*1000,Color.red);
            
    }

    public void CastRay()
    {
        if (Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hit.rayInfo,Mathf.Infinity))
        {
            Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward)*hit.rayInfo.distance,Color.cyan);
            //Debug.Log("did Hit");
            //Instantiate(ScriptableObject.CreateInstance<SO_Variables>());
            //Debug.Log(hit.rayInfo.collider.name);
        }
    }
}
