using System;
using UnityEngine;
using UnityEngine.UI;

public class Detection : MonoBehaviour
{
    public Button dPadButton;
    public SO_BoolArray bools;
    public int colliderID  =  -1;
    private void OnTriggerEnter(Collider other)
    {
        if (colliderID == 1)
        {
            bools.TR = false;
        }
        if (colliderID == 2)
        {
            bools.TM = false;
        }
        if (colliderID == 3)
        {
            bools.TL = false;
        }
        if (colliderID == 4)
        {
            bools.MR = false;
        }
        if (colliderID == 5)
        {
            bools.ML = false;
        }
        if (colliderID == 6)
        {
            bools.BR = false;
        }
        if (colliderID == 7)
        {
            bools.BM = false;
        }
        if (colliderID == 8)
        {
            bools.BL = false;
        }
    }
    

    private void OnTriggerExit(Collider other)
    {
        if (colliderID == 1)
        {
            bools.TR = true;
        }
        if (colliderID == 2)
        {
            bools.TM = true;
        }
        if (colliderID == 3)
        {
            bools.TL = true;
        }
        if (colliderID == 4)
        {
            bools.MR = true;
        }
        if (colliderID == 5)
        {
            bools.ML = true;
        }
        if (colliderID == 6)
        {
            bools.BR = true;
        }
        if (colliderID == 7)
        {
            bools.BM = true;
        }
        if (colliderID == 8)
        {
            bools.BL = true;
        }
    }
}
