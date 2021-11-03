using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraToRoom : MonoBehaviour
{
    int gridPos;
    void Start()
    {
        gridPos = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveCamera()
    {
        //TODO: add grid pos of the room
        Camera.main.transform.position = new Vector3();
    }
}
