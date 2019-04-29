using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomMB : MonoBehaviour
{
    private const float ScrollSpeed = 4;
    public static GameObject RoomPrefab;
    public static RoomMB ActiveRoom;

    private Room _meRoom;
    private RoomType _meType;
    private int _scrolling;

    private void Start()
    {
        ActiveRoom = this;
        _scrolling = -1;
        transform.position = new Vector3(25, 6, 5);
        name = "Room";
        SpriteRenderer bg = GetComponentInChildren<SpriteRenderer>();
        bg.sprite = Resources.Load<Sprite>("Backgrounds/bg0" + Random.Range(1, 4));
    }

    public void Init(RoomType t)
    {
        ActiveRoom = this;
        _meType = t;
        switch (t)
        {
            case RoomType.BattleRoom:
                _meRoom = new BattleRoom();
                break;
            case RoomType.ArtifactRoom:
                _meRoom = new ArtifactRoom();
                break;
            case RoomType.FountainRoom:
                _meRoom = new FountainRoom();
                break;
            default:
                throw new Exception("How could this have happened?");
        }
    }

    public void Exit()
    {
        _meRoom.Exit();
        _scrolling = 1;
    }

    private void Update()
    {
        if (_scrolling == -1)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, new Vector3(8, 6, 5), ScrollSpeed * Time.deltaTime);
            if (Mathf.Abs(transform.position.x - 8) < 0.01f)
            {
                transform.position = new Vector3(8, 6, 5);
                _scrolling = 0;
                Enter();
            }
        }
        else if (_scrolling == 1)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, new Vector3(-9, 6, 5), ScrollSpeed * Time.deltaTime);
            if (Mathf.Abs(transform.position.x + 9) < 0.01f)
                Destroy(gameObject);
        }
    }

    private void Enter()
    {
        _meRoom.Enter();
    }
}
