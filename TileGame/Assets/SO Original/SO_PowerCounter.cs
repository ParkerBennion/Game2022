using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class SO_PowerCounter : ScriptableObject
{
    public int points, powerUpCubes=0, powerUpCubes1=0, powerUpCubes2=0;
    public SO_Variables shuffle, generate, change, pointsToAdd;
    public SO_CallAction updateTextAction;


    public void AddPoint(int amnt)
    {
        powerUpCubes+= amnt;
        powerUpCubes1+= amnt;
        powerUpCubes2+= amnt;
        CheckCubes();
    }

    public void AddCubes()
    {
        AddPoint(pointsToAdd.intVar);
        Debug.Log("cubes added");
        updateTextAction.CallAction();
    }

    public void CheckCubes()
    {
        if (powerUpCubes >= 15)
        {
            //shuffel
            powerUpCubes -= 15;
            shuffle.intVar++;
            //buttonShuffel.clickable.
        }
        if (powerUpCubes1 >= 20)
        {
            //generate
            powerUpCubes1 -= 20;
            generate.intVar++;
            //buttonGenerate.interactable = true;
        }
        if (powerUpCubes2 >= 30)
        {
            //change
            powerUpCubes2 -= 30;
            change.intVar++;
            //buttonChange.interactable = true;
        }
    }
}
