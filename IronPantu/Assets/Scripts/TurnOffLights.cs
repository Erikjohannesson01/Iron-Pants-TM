using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffLights : MonoBehaviour
{
    bool clicked = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LightsOff()
    {
        //TODO: add code for turning off lights in room


        int actions = transform.parent.GetComponent<ActionsLeft>().cameraMap.GetComponent<RoomsToCameraMap>().actionsLeft;
        if (!clicked && actions > 0)
        {
            //TODO: Activate turret code
            transform.parent.GetComponent<ActionsLeft>().cameraMap.GetComponent<RoomsToCameraMap>().actionsLeft--;
            clicked = true;
        }
    }
}
