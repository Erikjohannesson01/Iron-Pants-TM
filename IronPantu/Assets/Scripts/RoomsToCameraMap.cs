using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomsToCameraMap : MonoBehaviour
{
    public Button room;
    GameObject[] rooms;
    float buttonRoomWidth;
    float buttonRoomHeight;
    float cameraHeight;
    float cameraWidth;
    float buttonOffsetX = 0;
    float buttonOffsetY = 0;
    void Start()
    {
        cameraHeight = Camera.main.scaledPixelHeight;
        cameraWidth = Camera.main.scaledPixelWidth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GetCameraMap()
    {
        rooms = GameObject.FindGameObjectsWithTag("Room");

        buttonRoomHeight = cameraHeight / rooms.Length;
        buttonRoomWidth = cameraWidth / rooms.Length;

        foreach(GameObject roomInArray in rooms)
        {
            Button roomInstance = Instantiate(room);
            //TODO: Add offsets for each button to fit the screen correctly;
            roomInstance.GetComponent<RectTransform>().rect.Set(transform.position.x,transform.position.y, buttonRoomWidth,buttonRoomHeight);
            buttonOffsetX = Camera.main.ScreenToWorldPoint(transform.position).x;
            buttonOffsetY = Camera.main.ScreenToWorldPoint(transform.position).y;
        }
    }
}
