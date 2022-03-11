using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPass : MonoBehaviour
{
    public SO_Color giveColorToTile;
    private MeshRenderer thisCubeRndr;
    private Material paintSplotch;

    private void OnTriggerEnter(Collider other)
    {
        
        MeshRenderer thisCubeRndr = GetComponent<MeshRenderer>();
        paintSplotch = thisCubeRndr.material;
        giveColorToTile.otherColor = paintSplotch;
        giveColorToTile.AddColors();
        Destroy(gameObject);
        
    }
}
