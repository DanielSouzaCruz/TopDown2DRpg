using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [SerializeField] private int woods;
    public int carrots;
    public float currentWater;

    [Header("limits")]
    private float waterLimit = 50;
    private float carrotsLimit = 30;
    private float woodLimit = 10;

    public int Woods { get => woods; set => woods = value; }
    public float WaterLimit { get => waterLimit; set => waterLimit = value; }
    public float CarrotsLimit { get => carrotsLimit; set => carrotsLimit = value; }
    public float WoodLimit { get => woodLimit; set => woodLimit = value; }

    public void WaterMaxLimit(float water)
    {
        if(currentWater <= WaterLimit)
        {
            currentWater += water;
        }
        
    }
}
