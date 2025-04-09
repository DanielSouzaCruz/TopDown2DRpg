using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [SerializeField] private int woods;
    public float currentWater;
    private float waterLimit = 50;

    public int Woods { get => woods; set => woods = value; }

    public void WaterMaxLimit(float water)
    {
        if(currentWater <= waterLimit)
        {
            currentWater += water;
        }
        
    }
}
