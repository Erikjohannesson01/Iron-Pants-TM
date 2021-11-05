using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorsAction : MonoBehaviour
{
    bool clicked = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CloseRoomDoors()
    {

        int actions = transform.parent.GetComponent<ActionsLeft>().cameraMap.GetComponent<RoomsToCameraMap>().actionsLeft;
        if (!clicked && actions > 0)
        {
            //TODO: Code to close doors
            transform.parent.GetComponent<ActionsLeft>().cameraMap.GetComponent<RoomsToCameraMap>().actionsLeft--;
            clicked = true;
        }
    }
}
