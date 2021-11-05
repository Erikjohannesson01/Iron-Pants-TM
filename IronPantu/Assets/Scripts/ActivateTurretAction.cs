using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTurretAction : MonoBehaviour
{
    bool clicked = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActivateTurret()
    {
        int actions = transform.parent.GetComponent<ActionsLeft>().cameraMap.GetComponent<RoomsToCameraMap>().actionsLeft;
        if (!clicked && actions > 0)
        {
            //TODO: Activate turret code
            transform.parent.GetComponent<ActionsLeft>().cameraMap.GetComponent<RoomsToCameraMap>().actionsLeft--;
            clicked = true;
        }
    }
}
