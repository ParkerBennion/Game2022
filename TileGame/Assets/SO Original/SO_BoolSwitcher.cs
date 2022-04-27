using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class SO_BoolSwitcher : ScriptableObject
{
    public bool specialBool = true;

    public void BoolTrue()
    {
        specialBool = true;
    }

    public void BoolFalse()
    {
        specialBool = false;
    }
}
