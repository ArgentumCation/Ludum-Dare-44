using System;
using UnityEngine;

public class RoomMB : MonoBehaviour
{
    public static GameObject RoomPrefab;
    public static RoomMB ActiveRoom;
    
    private Room _meRoom;
    private RoomType _meType;
    private int _scrolling;

    private void Start()
    {
        ActiveRoom = this;
        _scrolling = -1;
        transform.position = new Vector3(-9, 6, 5);
    }

    public void Init(Room r, RoomType t)
    {
        _meRoom = r;
        _meType = t;
    }

    public void Init(Room r)
    {
        _meRoom = r;
        
        if (r.GetType() == typeof(BattleRoom))
            _meType = RoomType.BattleRoom;
        else if (r.GetType() == typeof(ArtifactRoom))
            _meType = RoomType.ArtifactRoom;
        else if (r.GetType() == typeof(FountainRoom))
            _meType = RoomType.FountainRoom;
        else
            throw new ArgumentException("Unknown Room: " + r.GetType().FullName);
    }

    public void ScrollOut()
    {
        _scrolling = 1;
    }

    private void Update()
    {
        if (_scrolling == -1)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(8, 6, 5), 30 * Time.deltaTime);
            if (Mathf.Abs(transform.position.x - 8) < 0.01f)
            {
                transform.position = new Vector3(8, 6, 5);
                _scrolling = 0;
                Enter();
            }
        }
        else if (_scrolling == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(25, 6, 5), 30 * Time.deltaTime);
            if (Mathf.Abs(transform.position.x - 25) < 0.01f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Enter()
    {
        _meRoom.Enter();
    }
}