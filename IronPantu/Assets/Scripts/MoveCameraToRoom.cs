using System.Collections;
using System;
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
        cameraMap.transform.GetChild(1).gameObject.SetActive(false);
        cameraMap.transform.GetChild(2).gameObject.SetActive(false);

        GameObject cameraScreenInstance = Instantiate(cameraScreen);
        cameraScreenInstance.SetActive(true);
        List<Room> rooms = GameObject.Find("RoomController").GetComponent<RoomGenerator>().rooms;
        Room thisRoom = rooms[Int32.Parse(transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text.Substring(5))-1];
        Camera.main.transform.position = new Vector3(thisRoom.gridPos.x,thisRoom.gridPos.y,-10);
    }
}
