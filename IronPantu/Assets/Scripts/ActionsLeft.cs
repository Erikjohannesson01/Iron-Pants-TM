using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionsLeft : MonoBehaviour
{
    public GameObject cameraMap;
    public Room selectedRoom;
    void Start()
    {
        cameraMap = GameObject.Find("CameraMap");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Find("ActionsLeft").GetComponent<TMPro.TextMeshProUGUI>().text = "Actions Left " + cameraMap.GetComponent<RoomsToCameraMap>().actionsLeft;
    }
}
