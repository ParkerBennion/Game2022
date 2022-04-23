using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_BoolArray : ScriptableObject
{
    public bool TR, TM, TL, ML, MR, BL, BM, BR;

    public void AllTrue()
    {
        TR = true;
        TM = true;
        TL = true;
        ML = true;
        MR = true;
        BM = true;
        BR = true;
        BL = true;
    }
    public void ALLFalse()
    {
        TR = false;
        TM = false;
        TL = false;
        ML = false;
        MR = false;
        BM = false;
        BR = false;
        BL = false;
    }
}
