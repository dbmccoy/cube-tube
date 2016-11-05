using UnityEngine;
using System.Collections;

public class Utils{
    
    public static float round(float num, int digits) {
        float mult = Mathf.Pow(10.0f, (float)digits);
        return Mathf.Round(num * mult) / mult;
    }

}
