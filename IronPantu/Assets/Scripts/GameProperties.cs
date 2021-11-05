using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProperties : MonoBehaviour
{
    public static int gridDimensions;
    void Start()
    {
        gridDimensions = 6;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetGridDimensions(int grids)
    {
        gridDimensions = grids;
    }
    public int GetGridDimensions()
    {
        return gridDimensions;
    }
}
