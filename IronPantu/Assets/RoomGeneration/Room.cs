using UnityEngine;
using RoomEnums;
using System.Collections.Generic;

public class Room : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    public Vector2 gridPos;
    public RoomDirection direction;
    public RoomType type;
    public RoomExit exit;
    public int yDir = 0;
    public int xDir = 0;


    public Sprite Exit1, Exit2_1, Exit2_2, Exit3, Exit4;


    void Start()
    {

        switch (exit)
        {
            case RoomExit.Exit4:
                spriteRenderer.sprite = Exit4;
                break;
            case RoomExit.Exit3:
                spriteRenderer.sprite = Exit3;
                break;
            case RoomExit.Exit2_1:
                spriteRenderer.sprite = Exit2_1;
                break;
            case RoomExit.Exit2_2:
                spriteRenderer.sprite = Exit2_2;
                break;
            case RoomExit.Exit1:
                spriteRenderer.sprite = Exit1;
                break;
            default:
                spriteRenderer.sprite = Exit4;
                break;
        }


        if (direction == RoomDirection.North)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        else if (direction == RoomDirection.South)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        else if (direction == RoomDirection.East)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
        else if (direction == RoomDirection.West)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));


        if(type == RoomType.End) { spriteRenderer.color = Color.red; }
        else if(type == RoomType.Start) { spriteRenderer.color = Color.green; }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DecideRoom(List<Room> rooms)
    {
        int amountOfExist = 0;
        bool xCheck = false;
        bool yCheck = false;

        foreach (Room room in rooms)
        {
            if(gridPos + Vector2.up == room.gridPos) { amountOfExist++; yDir++; yCheck = true; }
            else if (gridPos + Vector2.down == room.gridPos) { amountOfExist++; yDir--; yCheck = true; }
            else if (gridPos + Vector2.right == room.gridPos) { amountOfExist++; xDir++; xCheck = true; }
            else if (gridPos + Vector2.left == room.gridPos) { amountOfExist++; xDir--; xCheck = true; }
        }

        switch (amountOfExist)
        {
            case 1:
                exit = RoomExit.Exit1;
                break;
            case 2:
                exit = RoomExit.Exit2_1;
                if (yDir != 0 && xDir != 0) { exit = RoomExit.Exit2_2; }
                break;
            case 3:
                exit = RoomExit.Exit3;
                break;
            default:
                exit = RoomExit.Exit4;
                break;
        }


        if(exit == RoomExit.Exit4) { Start(); return; }

        else if(exit == RoomExit.Exit1 || exit == RoomExit.Exit3)
        {
            if (Vector2.up == new Vector2(xDir, yDir)) { direction = RoomDirection.North; }
            else if (Vector2.down == new Vector2(xDir, yDir)) { direction = RoomDirection.South; }
            else if (Vector2.left == new Vector2(xDir, yDir)) { direction = RoomDirection.West; }
            else if (Vector2.right == new Vector2(xDir, yDir)) { direction = RoomDirection.East; }
        }

        else if(exit == RoomExit.Exit2_2)
        {
            if(new Vector2(-1, 1) == new Vector2(xDir, yDir)) { direction = RoomDirection.North; }
            else if(new Vector2(1, -1) == new Vector2(xDir, yDir)) { direction = RoomDirection.South; }
            else if (new Vector2(-1, -1) == new Vector2(xDir, yDir)) { direction = RoomDirection.West; }
            else if (new Vector2(1, 1) == new Vector2(xDir, yDir)) { direction = RoomDirection.East; }
        }

        else if (exit == RoomExit.Exit2_1)
        {
            if(xCheck) { direction = RoomDirection.East; }
            else if (yCheck) { direction = RoomDirection.North; }
        }



        Start();

    }


}
