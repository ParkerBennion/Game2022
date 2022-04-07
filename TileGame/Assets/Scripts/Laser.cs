using UnityEngine;

public class Laser : MonoBehaviour
{

    public SO_CastDat hit;
    private void Update()
    {
        int layerMask2 = 1 << 8;
        Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward)*1000,Color.red);
        if (Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hit.rayInfo,Mathf.Infinity,layerMask2))
        {
            
            Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward)*hit.rayInfo.distance,Color.cyan);
        }
    }

    public void CastRay()
    {
        int layerMask = 1 << 8;
        if (Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hit.rayInfo,Mathf.Infinity,layerMask))
        {
            Debug.Log(hit.rayInfo.collider.name);
        }
    }
}
