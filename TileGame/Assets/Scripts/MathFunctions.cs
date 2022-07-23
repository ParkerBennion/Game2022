using UnityEngine;

public class MathFunctions : MonoBehaviour
{
    public SO_Variables variables;
    public ButtonAction textUpdater;

    public void subtract()
    {
        
        if (variables.intVar<1)
        {
            Debug.Log("IF");
        }
        else
        {
            variables.intVar--;
            textUpdater.UpdateText();
            Debug.Log("ELSE");
        }
    }
}
