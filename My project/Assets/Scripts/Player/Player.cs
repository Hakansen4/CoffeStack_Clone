using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerMovement _Movement;
    CollectedCups _CollectedCups;
    private int Money;
    private void Awake()
    {
        Init();
    }
    private void Update()
    {
        _Movement.Move();
        _CollectedCups.MoveCollectedCups();
        Money = _CollectedCups.Money();
    }
    public void FinishMode()
    {
        _Movement.Finish();
    }
    private void Init()
    {
        Money = 0;
        _Movement = new PlayerMovement(transform);
        _CollectedCups = CollectedCups.GetInstance();
        _CollectedCups.PlayerTransform = transform;
    }
}
