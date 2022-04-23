using UnityEngine;
using Random = UnityEngine.Random;

public class MatExplorere : MonoBehaviour

{
    
    public Material newMat;
    public Vector4 colorCode;
    private Color codedColor;
    private MeshRenderer rndr;

    private void Start()
    {
        codedColor.r = colorCode.x;
        codedColor.g = colorCode.y;
        codedColor.b = colorCode.z;
        codedColor.a = colorCode.w;
        MeshRenderer rndr = GetComponent<MeshRenderer>();
        rndr.material.color = codedColor;
        SetRandom();

        //manually sets a color
    }


    public void ColorChange()
    {
        newMat.color += codedColor;
        if (newMat.color.a > 1)
        {
            Debug.Log(newMat.color.a);
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

        //activates scripts
    }

    public void SetRandom()
    {
        MeshRenderer thisRndr = GetComponent<MeshRenderer>();

        Material randomMaterial;
        (randomMaterial = thisRndr.material).color = Random.ColorHSV(0f,1f,1f,1f,1f,1f,.7f,.7f);
        codedColor = randomMaterial.color;
        
        //goes crazy
    }
}
