using System.Collections.Generic;
using UnityEngine;
using RoomEnums;

public class RoomGenerator : MonoBehaviour
{
    private Vector3 offset;
    public int gridDimensions;
    [SerializeField, Range(0, 1)]
    private float randomPahting;
    public GameObject Room;

    public List<Room> rooms = new List<Room>();

    void Start()
    {
        offset = transform.position + new Vector3(0.5f, 0.5f);
        InitializeGeneration();
        RandomWalk();
    }


    void Update()
    {

    }


    private void InitializeGeneration()
    {

        //Create Start/Spawn Room.
        newRoom(Vector3.zero, RoomType.Start, RoomDirection.North, RoomExit.Exit4);
        //Create End/Exit Room.
        newRoom(new Vector3(gridDimensions - 1, gridDimensions - 1), RoomType.End, RoomDirection.South, RoomExit.Exit4);
      
    }

    private void RandomWalk()
    {
        float movePreference = randomPahting;
        Vector2 _currentPos = rooms[0].gridPos;
        Room oldRoom = rooms[0];

        while (true)
        {
            Vector2 _tempPos = _currentPos;
            float randomMove = Random.value;
            Vector2 moveDir = BestMove(_currentPos, rooms[1].gridPos);

            if(randomMove < movePreference)
            {
                movePreference -= randomPahting / 10;
                randomMove = Random.value;
                if (randomMove < 0.25f) { moveDir = Vector2.up; }
                else if (randomMove < 0.5f) { moveDir = Vector2.down; }
                else if (randomMove < 0.75f) { moveDir = Vector2.left; }
                else{ moveDir = Vector2.right; }
            } else
            {
                movePreference = randomPahting;
            }

            _tempPos += moveDir;


            if (_tempPos == rooms[1].gridPos) { break; }
            if (_tempPos == rooms[0].gridPos) { continue; }
            if (_tempPos == _currentPos) { continue; }

            if ((_tempPos.x >= 0 && _tempPos.y >= 0) && (_tempPos.x <= gridDimensions - 1 && _tempPos.y <= gridDimensions - 1))
            {
                bool _check = false;
                foreach (Room room in rooms)
                {
                    if (_tempPos == room.gridPos) { _check = true; }
                }

                if (!_check)
                {
                    oldRoom = newRoom(new Vector3(_tempPos.x, _tempPos.y), RoomType.Normal, RoomDirection.North, RoomExit.Empty);
                }

                _currentPos = _tempPos;
            }
        }

        foreach (Room room in rooms)
        {
            room.DecideRoom(rooms);
        }

    }

    private Vector2 BestMove(Vector2 pos, Vector2 dest)
    {


        Vector2 _holder = Vector2.zero;

        if ((pos + Vector2.up - dest).magnitude < (pos + _holder - dest).magnitude)
        {
            _holder = Vector2.up;
        }
        if ((pos + Vector2.down - dest).magnitude < (pos + _holder - dest).magnitude)
        {
            _holder = Vector2.down;
        }
        if ((pos + Vector2.left - dest).magnitude < (pos + _holder - dest).magnitude)
        {
            _holder = Vector2.left;
        }
        if ((pos + Vector2.right - dest).magnitude < (pos + _holder - dest).magnitude)
        {
            _holder = Vector2.right;
        }

        return _holder;
    }

    private Room newRoom(Vector3 pos, RoomType type, RoomDirection direction, RoomExit exit)
    {
        GameObject _newRoom = Instantiate(Room, offset + pos, Quaternion.identity, transform);
        Room _roomScript = _newRoom.GetComponent<Room>();

        _roomScript.gridPos = pos;
        _roomScript.type = type;
        _roomScript.direction = direction;
        _roomScript.exit = exit;

        rooms.Add(_roomScript);

        return _roomScript;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        for (int i = 0; i < gridDimensions; i++)
        {
            Gizmos.DrawLine(transform.position + new Vector3(0, i, 0), transform.position + new Vector3(gridDimensions, i, 0));
        }

        for (int i = 0; i < gridDimensions; i++)
        {
            Gizmos.DrawLine(transform.position + new Vector3(i, 0, 0), transform.position + new Vector3(i, gridDimensions, 0));
        }

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, gridDimensions, 0));
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(gridDimensions, 0, 0));
        Gizmos.DrawLine(transform.position + new Vector3(gridDimensions, gridDimensions, 0), transform.position + new Vector3(gridDimensions, 0, 0));
        Gizmos.DrawLine(transform.position + new Vector3(gridDimensions, gridDimensions, 0), transform.position + new Vector3(0, gridDimensions, 0));
    }
}

