using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBack : MonoBehaviour
{
    GameObject cameraMap;
        
    void Start()
    {
        cameraMap = GameObject.Find("CameraMap");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoBackOnClick()
    {
        cameraMap.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        cameraMap.gameObject.transform.GetChild(2).gameObject.SetActive(true);
        Destroy(transform.parent.gameObject);
    }
}
