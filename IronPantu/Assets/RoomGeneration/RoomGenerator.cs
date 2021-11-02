using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    private Vector3 _test;
    public int gridDimensions;
    public GameObject StartRoom, EndRoom, Room;

    [SerializeField] private List<Room> rooms = new List<Room>();

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
        _end.GetComponent<Room>().gridPos = new Vector2(0, 0);

        rooms.Add(_end.GetComponent<Room>());

    }

    private void RandomWalk()
    {
        Vector2 _currentPos = rooms[0].gridPos;
        
        for(int i = 0; i < 50; i++)
        {
            Vector2 _tempPos = _currentPos;
            float randomMove = Random.value;
            Vector2 movePreference = BestMove(_currentPos, rooms[1].gridPos);
            _tempPos += movePreference;


            //if (_tempPos == rooms[1].gridPos) { break; }
            if(_tempPos != _currentPos)
            {
                Instantiate(Room, _test + new Vector3(_tempPos.x, _tempPos.y), Quaternion.identity, transform);

                _currentPos = _tempPos;
            }

        }

    }

    private Vector2 BestMove(Vector2 pos, Vector2 dest)
    {
        Vector2 _holder = Vector2.zero;

        if(((pos + Vector2.up) + dest).magnitude < ((pos + _holder) + dest).magnitude)
        {
            _holder = Vector2.up;
        }
        if (((pos + Vector2.down) + dest).magnitude < ((pos + _holder) + dest).magnitude)
        {
            _holder = Vector2.down;
        }
        if (((pos + Vector2.left) + dest).magnitude < ((pos + _holder) + dest).magnitude)
        {
            _holder = Vector2.right;
        }
        if (((pos + Vector2.right) + dest).magnitude < ((pos + _holder) + dest).magnitude)
        {
            _holder = Vector2.left;
        }


        return _holder;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        for(int i = 0; i < gridDimensions; i++)
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

