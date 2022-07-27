using System.Collections;
using UnityEngine;

public class PaintRefreshSpawner : MonoBehaviour
{
    //private SO_Variables paintCarePackage, usedAmnt;
    public GridLayout gridhere;
    private WaitForSeconds awaitCubePlace;
    public GameObject instanceObj;
    private Vector3 cubeSpawn, cubeSpawn2, cubeSpawn3, cubeSpawn4, cubeSpawn5, cubeSpawn6, cubeSpawn7, cubeSpawn8;
    

    public void StartDeployPackage(SO_Variables paintUses)
    {
        StartCoroutine(DeployPackage(paintUses));
    }

    IEnumerator DeployPackage(SO_Variables paintUses)
    {
        
        var setRotation = transform.rotation;
        awaitCubePlace = new WaitForSeconds(.1f);
        cubeSpawn = gridhere.CellToWorld(new Vector3Int(-1, 0, 1));
        cubeSpawn2 = gridhere.CellToWorld(new Vector3Int(-1, 0, 0));
        cubeSpawn3 = gridhere.CellToWorld(new Vector3Int(-1, 0, -1));
        cubeSpawn4 = gridhere.CellToWorld(new Vector3Int(1, 0, 1));
        cubeSpawn5 = gridhere.CellToWorld(new Vector3Int(1, 0, 0));
        cubeSpawn6 = gridhere.CellToWorld(new Vector3Int(1, 0, -1));
        cubeSpawn7 = gridhere.CellToWorld(new Vector3Int(0, 0, 1));
        cubeSpawn8 = gridhere.CellToWorld(new Vector3Int(0, 0, -1));

        if (paintUses.intVar > 0)
        {
            
            Instantiate(instanceObj, cubeSpawn, setRotation);
            Instantiate(instanceObj, cubeSpawn2, setRotation);
            Instantiate(instanceObj, cubeSpawn3, setRotation);
            Instantiate(instanceObj, cubeSpawn4, setRotation);
            Instantiate(instanceObj, cubeSpawn5, setRotation);
            Instantiate(instanceObj, cubeSpawn6, setRotation);
            Instantiate(instanceObj, cubeSpawn7, setRotation);
            Instantiate(instanceObj, cubeSpawn8, setRotation);
            //paintUses.intVar -= 1;
        }

        yield break;
    }

}
