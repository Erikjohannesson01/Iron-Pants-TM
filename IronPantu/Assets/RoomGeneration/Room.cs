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

    public bool openDoors = true;


    public RoomFunctions roomFunc;

    public GameObject G_Exit1, G_Exit2_1, G_Exit2_2, G_Exit3, G_Exit4, Enemy;

    void Start()
    {

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
        int yDir = 0;
        int xDir = 0;

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


        if(exit == RoomExit.Exit4) { EnableRoom(); return; }

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

        EnableRoom();
    }

    public void EnableRoom()
    {
        GameObject _temp;
        switch (exit)
        {
            case RoomExit.Exit3:
                _temp = Instantiate(G_Exit3, transform);
                break;
            case RoomExit.Exit2_1:
                _temp = Instantiate(G_Exit2_1, transform);
                break;
            case RoomExit.Exit2_2:
                _temp = Instantiate(G_Exit2_2, transform);
                break;
            case RoomExit.Exit1:
                _temp = Instantiate(G_Exit1, transform);
                break;
            default:
                _temp = Instantiate(G_Exit4, transform);
                break;
        }

        if (direction == RoomDirection.North)
            _temp.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        else if (direction == RoomDirection.South)
            _temp.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        else if (direction == RoomDirection.East)
            _temp.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
        else if (direction == RoomDirection.West)
            _temp.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));


        if(type != RoomType.Start && type != RoomType.End)
        type = (RoomType)Mathf.RoundToInt(Random.Range(2, 4));

        if(type == RoomType.Enemy)
        {
            float spawnRadius = 0.25f;
            int amountOfEnemies = Mathf.RoundToInt(Random.Range(1, 3));
            Vector2[] positions = new Vector2[amountOfEnemies];

            for (int i = 0; i < amountOfEnemies; i++)
            {
                Vector3 pos = randomEnemyPos();
                if (i > 0)
                {
                    if(Mathf.Pow(pos.x - positions[i-1].x, 2) + Mathf.Pow(pos.y - positions[i-1].y, 2) > (spawnRadius * spawnRadius))
                    {
                        Instantiate(Enemy, pos, Quaternion.identity);

                        positions[i] = pos;
                    }
                    else
                    {
                        i -= 1;
                        continue;
                    }
                } else
                {
                    Instantiate(Enemy, pos, Quaternion.identity);

                    positions[i] = pos;
                }
            }
        }

    }


    private Vector3 randomEnemyPos()
    {
        return new Vector3(
           Random.Range(transform.position.x - 0.3f, transform.position.x + 0.3f),
           Random.Range(transform.position.y - 0.3f, transform.position.y + 0.3f),
           -1
       );
    }

}
