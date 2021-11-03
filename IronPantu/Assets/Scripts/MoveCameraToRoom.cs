using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraToRoom : MonoBehaviour
{
    int gridPos;
    public GameObject cameraScreen;
    GameObject cameraMap;
    void Start()
    {
        cameraMap = GameObject.Find("CameraMap");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveCamera()
    {
        //TODO: add grid pos of the room
        cameraMap.transform.GetChild(0).gameObject.SetActive(false);
        cameraMap.transform.GetChild(1).gameObject.SetActive(false);

        GameObject cameraScreenInstance = Instantiate(cameraScreen);
        cameraScreenInstance.SetActive(true); ;
       // Camera.main.transform.position = new Vector3();
    }
}
