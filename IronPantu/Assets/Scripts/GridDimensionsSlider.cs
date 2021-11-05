using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GridDimensionsSlider : MonoBehaviour
{
    public int gridDimensions;
    public Slider slider;
    public GameObject text;
    public GameObject gameProps;
    void Start()
    {
        text.GetComponent<TMPro.TextMeshProUGUI>().text = "Grid Dimenstions: " + gridDimensions;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeGridDimensions()
    {
        gridDimensions = (int)slider.value;
        text.GetComponent<TMPro.TextMeshProUGUI>().text = "Grid Dimenstions: " + gridDimensions;
        gameProps.GetComponent<GameProperties>().SetGridDimensions(gridDimensions);
    }
}
