using System;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class Utils
{
    public static Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = UnityEngine.Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }
}

public static class mColors
{
    public static Color orange = new Color(1f, .5f, 0f, 1f);
}

