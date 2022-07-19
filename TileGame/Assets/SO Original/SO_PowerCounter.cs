using UnityEngine;

[CreateAssetMenu]
public class SO_PowerCounter : ScriptableObject
{
    public int points, powerUpCubes, powerUpCubes1, powerUpCubes2;

    public void AddPoint(int pont, int pont2, int pont3)
    {
        pont++;
        pont2++;
        pont3++;
        if (pont+ pont2 + pont3 == 0 )
        {
            pont+= 7;
            pont2+= 7;
            pont3+= 7;
        }
        CheckCubes();
    }

    public void AddCubes()
    {
        AddPoint(powerUpCubes,powerUpCubes1, powerUpCubes2);
    }

    public void CheckCubes()
    {
        if (powerUpCubes >= 15)
        {
            powerUpCubes -= 15;
        }
        if (powerUpCubes1 >= 20)
        {
            powerUpCubes1 -= 20;
        }
        if (powerUpCubes2 >= 30)
        {
            powerUpCubes2 -= 30;
        }
    }
}
