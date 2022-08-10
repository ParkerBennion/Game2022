using UnityEngine;

[CreateAssetMenu]

public class SO_Color : ScriptableObject
{
    public Material tileColor;
    public Material otherColor;
    
    public Color thisTilesColor;
    public Color passedColor;
    
    

    
    public void ResetCanvas()
    {
        tileColor.color = Color.white;
        
        thisTilesColor = tileColor.color;
        
        thisTilesColor.a = .7f;
    }
    
    public void AddColors()
    {
        thisTilesColor.r += otherColor.color.r;
        thisTilesColor.g += otherColor.color.g;
        thisTilesColor.b += otherColor.color.b;
        //adds the current tile color to the color of the paint that has been hit;

        thisTilesColor.r *= .5f;
        thisTilesColor.g *= .5f;
        thisTilesColor.b *= .5f;
        thisTilesColor.a = .7f;
        // divides in half the value to "mix" the colors

        thisTilesColor.a = Mathf.Clamp(thisTilesColor.a, 0, 1);
        thisTilesColor.r = Mathf.Clamp(thisTilesColor.r, 0, 1);
        thisTilesColor.g = Mathf.Clamp(thisTilesColor.g, 0, 1);
        thisTilesColor.b = Mathf.Clamp(thisTilesColor.b, 0, 1);
        //clamps the value into acceptable range in case color values get too high
        
        //Debug.Log(thisTilesColor+"thisTilesColor");

        tileColor.color = thisTilesColor;
        // takes the material of the players cube and sets it to new mixed value.
        
        passedColor = thisTilesColor;
        // variable set to use in other scripts.
    }

    public void LogColor()
    {
        Debug.Log(otherColor.color);
    }

    public void SetOtherColor()
    {
       
    }
}
