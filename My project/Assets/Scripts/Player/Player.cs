using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerMovement _Movement;
    CollectedCups _CollectedCups;
    private void Awake()
    {
        Init();
    }
    private void Play()
    {
        _Movement.Move();
        _CollectedCups.MoveCollectedCups();
    }
    private void Init()
    {
        _Movement = new PlayerMovement(transform);
        _CollectedCups = CollectedCups.GetInstance();
        _CollectedCups.PlayerTransform = transform;
    }
}
