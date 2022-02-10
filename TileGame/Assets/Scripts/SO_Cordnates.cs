using UnityEngine;

[CreateAssetMenu]
public class SO_Cordnates : ScriptableObject
{
    public Vector3 currentCord;
    public Vector3 addedCord;

    public void AddVector(Vector3 vecto)
    {
        Vector3 currentCord = vecto + this.currentCord;
        
        Debug.Log(currentCord);
    }
}