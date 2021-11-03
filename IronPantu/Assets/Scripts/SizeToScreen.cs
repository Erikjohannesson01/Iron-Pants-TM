using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeToScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(Camera.main.pixelHeight,Camera.main.pixelWidth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
