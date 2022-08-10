using UnityEngine;
using Random = UnityEngine.Random;

public class MatExplorere : MonoBehaviour

{
    
    public Material newMat;
    public Vector4 colorCode;
    private Color codedColor;
    private MeshRenderer rndr;
    public SO_Variables shuffleCount;

    //set variables
    public float
        hueMin = 0, hueMax = 1,
        
        saturationMin = .4f, saturationMax = 1f,
        
        valueMin = .6f, valueMax = 1f,
        
        alphaMax = .7f, alphaMin = .7f;

    
        private void Start()
    {
        codedColor.r = colorCode.x;
        codedColor.g = colorCode.y;
        codedColor.b = colorCode.z;
        codedColor.a = colorCode.w;
        MeshRenderer rndr = GetComponent<MeshRenderer>();
        rndr.material.color = codedColor;
        SetRandom();

        //manually sets a color to be referenced
    }


    public void ColorChange()
    {
        newMat.color += codedColor;
        if (newMat.color.a > 1)
        {
            //Debug.Log(newMat.color.a);
        }

        //applies color
    }

    private void ColorStrip()
    {
        newMat.color -= codedColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Paint"))
        {
            ColorChange();
            
            Destroy(gameObject); 
        }

        if (gameObject.CompareTag("Thinner"))
        {
            ColorStrip();
            
            Destroy(gameObject);
        }

        //destroyes paint blocks
        //activates scripts
    }

    public void SetRandomUnlessNull()
    {
        if (shuffleCount.intVar>=1)
        {
            MeshRenderer thisRndr = GetComponent<MeshRenderer>();

            Material randomMaterial;
            (randomMaterial = thisRndr.material).color = Random.ColorHSV(hueMin,hueMax,saturationMin,saturationMax,valueMin,valueMax,alphaMin,alphaMax);
            codedColor = randomMaterial.color;
        
            //goes crazy and sets colors to random values.
            // only works if player has powerup points
        }
        
    }
    public void SetRandom()
    {
        
            MeshRenderer thisRndr = GetComponent<MeshRenderer>();

            Material randomMaterial;
            (randomMaterial = thisRndr.material).color = Random.ColorHSV(hueMin,hueMax,saturationMin,saturationMax,valueMin,valueMax,alphaMin,alphaMax);
            codedColor = randomMaterial.color;
        
            //goes crazy and sets colors to random values.
    }
    //see SO_Color for mixing functions.
}
