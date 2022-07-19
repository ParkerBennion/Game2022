using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAction : MonoBehaviour
{
    public Text buttonText;
    public SO_Variables powerUp;
    
    public void UpdateText()
    {
        buttonText.text = powerUp.intVar.ToString();
    }

    private void Start()
    {
        buttonText.text = powerUp.intVar.ToString();
    }
}
