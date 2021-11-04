using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomsToCameraMap : MonoBehaviour
{
    public Button cameraRoom;
    public Canvas background;
    public Canvas cameraCanvas;
    public GameObject securityPanel;
    bool inCameraMap = false;
    bool cameraMapGenerated = false;
    float cellHeight;
    float cellWidth;
    int gridDimentions;
    public int actionsLeft = 8;
    void Start()
    {
        gridDimentions = GameObject.Find("RoomController").GetComponent<RoomGenerator>().gridDimensions;
    }

    // Update is called once per frame
    void Update()
    {
        ActivateMap();
    }
    void GetCameraMap()
    {
        Instantiate(background, transform);
        Canvas cameraCanvasInstance = Instantiate(cameraCanvas, transform);
        cellWidth = cameraCanvasInstance.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.x / gridDimentions;
        cellHeight = cameraCanvasInstance.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.y / gridDimentions;


        int roomCount = 1;
        List<Room> rooms = GameObject.Find("RoomController").GetComponent<RoomGenerator>().rooms;

        foreach(Room room in rooms)
        {
            Button instanceButton = Instantiate(cameraRoom, cameraCanvasInstance.transform.GetChild(0).transform.GetChild(0).transform);
            instanceButton.transform.position = new Vector3(room.gridPos.x*cellWidth,room.gridPos.y*cellHeight);
            instanceButton.GetComponent<RectTransform>().sizeDelta = new Vector2(cellWidth, cellHeight);
            instanceButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Room " + roomCount;

            roomCount++;
        }
    }
    void ActivateMap()
    {


        if (Input.GetKeyDown(KeyCode.E) && !inCameraMap && securityPanel.GetComponent<CheckPlayerNear>().PlayerInRange)
        {
            if (!cameraMapGenerated)
            {
                GetCameraMap();
                actionsLeft = GameObject.Find("RoomController").transform.childCount;
                cameraMapGenerated = true;
            }
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            inCameraMap = true;

        }
        else if (Input.GetKeyDown(KeyCode.E) && securityPanel.GetComponent<CheckPlayerNear>().PlayerInRange)
        {
            GameObject cameraScreen = GameObject.Find("InCameraScreen(Clone)");
            Destroy(cameraScreen);
            GameObject player = GameObject.Find("Player");
            Camera.main.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
            inCameraMap = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
