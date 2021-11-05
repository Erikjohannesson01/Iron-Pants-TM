using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFunctions : MonoBehaviour
{
    Room parent;
    public GameObject doors;
    void Start()
    {
        parent = GetComponentInParent<Room>();

        parent.roomFunc = GetComponent<RoomFunctions>();

    }


    public void doorAction(bool openDoors)
    {
        if(!openDoors) { doors.SetActive(true); }
        if(openDoors) { doors.SetActive(false); }
    }



}
