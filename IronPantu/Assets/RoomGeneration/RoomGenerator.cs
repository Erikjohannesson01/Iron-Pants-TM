using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    private Vector3 _test;
    public int gridDimensions;
    public GameObject StartRoom, EndRoom, Room;

    public List<Room> rooms = new List<Room>();

    void Start()
    {
        _test = transform.position + new Vector3(0.5f, 0.5f);
        InitializeGeneration();
        RandomWalk();
    }


    void Update()
    {

    }


    private void InitializeGeneration()
    {
        //Create a start and End Point.

        GameObject _start = Instantiate(StartRoom, _test + new Vector3(0, 0, 0), Quaternion.identity, transform);
        _start.GetComponent<Room>().gridPos = new Vector2(0, 0);

        rooms.Add(_start.GetComponent<Room>());

        GameObject _end = Instantiate(EndRoom, _test + new Vector3(gridDimensions - 1, gridDimensions - 1, 0), Quaternion.identity, transform);
        _end.GetComponent<Room>().gridPos = new Vector2(gridDimensions - 1, gridDimensions - 1);

        rooms.Add(_end.GetComponent<Room>());

    }

    private void RandomWalk()
    {
        Vector2 _currentPos = rooms[0].gridPos;

        while (true)
        {
            Vector2 _tempPos = _currentPos;
            float randomMove = Random.value;
            Vector2 movePreference = BestMove(_currentPos, rooms[1].gridPos);

            if (randomMove > 0.8f)
                _tempPos += movePreference;
            else
            {
                randomMove = Random.value;
                if (randomMove < 0.25f)
                {
                    _tempPos += Vector2.up;
                }
                else if (randomMove < 0.5f)
                {
                    _tempPos += Vector2.down;
                }
                else if (randomMove < 0.75f)
                {
                    _tempPos += Vector2.left;
                }
                else
                {
                    _tempPos += Vector2.right;
                }
            }

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
                    GameObject _tempRoom = Instantiate(Room, _test + new Vector3(_tempPos.x, _tempPos.y), Quaternion.identity, transform);
                    _tempRoom.GetComponent<Room>().gridPos = new Vector2(_tempPos.x, _tempPos.y);

                    rooms.Add(_tempRoom.GetComponent<Room>());
                }

                _currentPos = _tempPos;
            }
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

