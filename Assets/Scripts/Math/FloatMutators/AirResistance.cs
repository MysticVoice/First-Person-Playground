using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AirResistance
{
    public static float CalculateAirResistance(float speed,float mass,float area, float airDensity, float dragCoefficient)
    {
        float drag = dragCoefficient * (((airDensity * Mathf.Pow(speed, 2)) / 2) * area);
        float a = (mass - drag) / mass;
        return a;
    }
}
