using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridInstanceScript : MonoBehaviour
{
    public GridLayout gridhere;
    public Grid otherGrid;
    public GridBrushBase gridBrush;
    public GameObject instanceObj;
    private Vector3 cubeSpawn;
    private Vector3 cubeSpawn2;
    public int currentCube=0, finalCube=1;
    private WaitForSeconds awaitCubePlace;
    

    private void Start()
    {
        // cubeSpawn = otherGrid.LocalToCell(new Vector3(3,0,0));
        // cubeSpawn2 = otherGrid.LocalToCell(new Vector3(-3,0,0));
        var setRotation = transform.rotation;
        // Instantiate(instanceObj, cubeSpawn, setRotation);
        // Instantiate(instanceObj, cubeSpawn2, setRotation);
        cubeSpawn = gridhere.CellToLocal(new Vector3Int(30, 1, 1));
        Instantiate(Instantiate(instanceObj, cubeSpawn, setRotation));

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            generateLevel();
        }
    }

    private void SpawnCube()
    {
        var setRotation = transform.rotation;
        Instantiate(Instantiate(instanceObj, cubeSpawn, setRotation));
    }

    public void generateLevel()
    {
        StartCoroutine(GenerateNextLevel());
    }
    
    IEnumerator GenerateNextLevel()
    {
        var setRotation = transform.rotation;
        awaitCubePlace = new WaitForSeconds(.1f);
        cubeSpawn = gridhere.CellToWorld(new Vector3Int(-2, 0, 1));

        while (currentCube < finalCube)
        {
            
            Instantiate(Instantiate(instanceObj, cubeSpawn, setRotation));
            currentCube += 1;
            cubeSpawn += new Vector3(5, 0, 0);
            yield return awaitCubePlace;
        }

        currentCube = 0;
        cubeSpawn = gridhere.CellToWorld(new Vector3Int(-2, 0, 2));

        while (currentCube < finalCube)
        {
            Instantiate(Instantiate(instanceObj, cubeSpawn, setRotation));
            currentCube += 1;
            cubeSpawn += new Vector3(5, 0, 0);
            yield return awaitCubePlace;
        }
        
        currentCube = 0;
        cubeSpawn = gridhere.CellToWorld(new Vector3Int(-2, 0, 3));
        while (currentCube < finalCube)
            
        {
            Instantiate(Instantiate(instanceObj, cubeSpawn, setRotation));
            currentCube += 1;
            cubeSpawn += new Vector3(5, 0, 0);
            yield return awaitCubePlace;
        }

        currentCube = 0;
        
        
        
        yield break;
        
        
    }
    //cubeSpawn = gridhere.CellToLocal(new Vector3Int(30, 1, 1));
}
