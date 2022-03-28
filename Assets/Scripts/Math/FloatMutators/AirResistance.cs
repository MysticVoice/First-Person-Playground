using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirResistance : FloatMutator
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float mass;
    [SerializeField]
    private float area;
    [SerializeField]
    private float airDensity;
    [SerializeField]
    private float dragCoefficient;
    public override float Calculate(float speed)
    {
        return CalculateAirResistance(speed,mass,area,airDensity,dragCoefficient);
    }

    public float CalculateAirResistance(float speed,float mass,float area, float airDensity, float dragCoefficient)
    {
        float drag = dragCoefficient * (((airDensity * Mathf.Pow(speed, 2)) / 2) * area);
        float a = (mass - drag) / mass;
        return a;
    }
}
