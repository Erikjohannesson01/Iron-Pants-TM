using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomsToCameraMap : MonoBehaviour
{
    public Button room;
    public Canvas background;
    public Canvas cameraCanvas;
    GameObject[] rooms;
    string tagToLookFor = "Rooms";
    bool inCameraMap = false;
    bool cameraMapGenerated = false;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !inCameraMap)
        {
            if (!cameraMapGenerated)
            {
                GetCameraMap();
                cameraMapGenerated = true;
            }
            else
            {
                gameObject.SetActive(true);
            }
            inCameraMap = true;
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            gameObject.SetActive(false);
            inCameraMap = false;
        }
    }
    void GetCameraMap()
    {
        rooms = new GameObject[GameObject.FindGameObjectsWithTag(tagToLookFor).Length];
        rooms = GameObject.FindGameObjectsWithTag(tagToLookFor);
        int roomCount = 1;
        Instantiate(background, transform);
        Canvas cameraCanvasInstance = Instantiate(cameraCanvas, transform);
        foreach (GameObject roomInArray in rooms)
        {
            Button roomInstance = Instantiate(room, cameraCanvasInstance.transform);
            roomInstance.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Room" + roomCount;
            roomCount++;
        }
    }
}
