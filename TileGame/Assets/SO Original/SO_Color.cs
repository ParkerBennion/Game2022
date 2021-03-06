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
    public Color thisTilesColor;
    public Color passedColor;
    
    

    
    public void ResetCanvas()
    {
        tileColor.color = Color.white;
        
        // redValue = tileColor.color.r;
        // greenValue = tileColor.color.g;
        // blueValue = tileColor.color.b;
        // alphaValue = tileColor.color.a;|
        thisTilesColor = tileColor.color;
        // thisTilesColor.r = .0f;
        // thisTilesColor.g = .0f;
        // thisTilesColor.b = .0f;
        thisTilesColor.a = .7f;
    }
    
    public void AddColors()
    {
        // redValue -= otherColor.color.r;
        // blueValue -= otherColor.color.b;
        // greenValue -= otherColor.color.g;
        //thisTilesColor.r -= redValue;
        
        thisTilesColor.r += otherColor.color.r;
        thisTilesColor.g += otherColor.color.g;
        thisTilesColor.b += otherColor.color.b;
        //thisTilesColor.a += otherColor.color.a;

        thisTilesColor.r *= .5f;
        thisTilesColor.g *= .5f;
        thisTilesColor.b *= .5f;
        thisTilesColor.a = .7f;
        
       

        thisTilesColor.a = Mathf.Clamp(thisTilesColor.a, 0, 1);
        thisTilesColor.r = Mathf.Clamp(thisTilesColor.r, 0, 1);
        thisTilesColor.g = Mathf.Clamp(thisTilesColor.g, 0, 1);
        thisTilesColor.b = Mathf.Clamp(thisTilesColor.b, 0, 1);
        
        //Debug.Log(thisTilesColor+"thisTilesColor");

        tileColor.color = thisTilesColor;
        passedColor = thisTilesColor;
    }

    public void LogColor()
    {
        Debug.Log(otherColor.color);
    }

    public void SetOtherColor()
    {
       
    }
}
