using UnityEngine;

[CreateAssetMenu]

public class SO_Color : ScriptableObject
{
    public Material tileColor;
    public Material otherColor;
    public float boundOne;
    public float boundTwo;
    public string colorVar;
    private float redValue,greenValue,blueValue,alphaValue;
    private Color thisTilesColor;
    

    
    public void ResetCanvas()
    {
        tileColor.color = Color.clear;
        
        // redValue = tileColor.color.r;
        // greenValue = tileColor.color.g;
        // blueValue = tileColor.color.b;
        // alphaValue = tileColor.color.a;|
        thisTilesColor = tileColor.color;
    }
    
    public void AddColors()
    {
        // redValue -= otherColor.color.r;
        // blueValue -= otherColor.color.b;
        // greenValue -= otherColor.color.g;
        //thisTilesColor.r -= redValue;
        
        thisTilesColor.r += otherColor.color.r/4;
        thisTilesColor.g += otherColor.color.g/4;
        thisTilesColor.b += otherColor.color.b/4;
        thisTilesColor.a += otherColor.color.a/4;
       

        thisTilesColor.a = Mathf.Clamp(thisTilesColor.a, 0, 1);
        thisTilesColor.r = Mathf.Clamp(thisTilesColor.r, 0, 1);
        thisTilesColor.g = Mathf.Clamp(thisTilesColor.g, 0, 1);
        thisTilesColor.b = Mathf.Clamp(thisTilesColor.b, 0, 1);
        
        //Debug.Log(thisTilesColor+"thisTilesColor");

        tileColor.color = thisTilesColor;
    }

    public void LogColor()
    {
        Debug.Log(otherColor.color);
    }

    public void SetOtherColor()
    {
       
    }
}
