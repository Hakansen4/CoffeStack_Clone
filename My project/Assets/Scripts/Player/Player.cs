using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    PlayerMovement _Movement;
    CollectedCups _CollectedCups;
    private int Money;
    private bool finished;
    [SerializeField] private Transform Hand;
    [SerializeField] private TextMeshProUGUI MoneyText;
    private void Awake()
    {
        Init();
    }
    private void Update()
    {
        _Movement.Move();
        _CollectedCups.MoveCollectedCups();
        MoneyCheck();
    }
    private void MoneyCheck()
    {
        if (!finished)
        {
            Money = _CollectedCups.Money();
        }
        MoneyText.text = _CollectedCups.Money().ToString() + "  $";
    }
    public void FinishMode()
    {
        finished = true;
        _Movement.Finish();
    }
    public void LevelEndMode(float ManagerMoney,float CupsMoney)
    {
        _Movement.LevelEnd(ManagerMoney, CupsMoney, Hand);
    }
    public int GetMoney()
    {
        return Money;
    }
    private void Init()
    {
        Money = 0;
        _Movement = new PlayerMovement(transform);
        _CollectedCups = CollectedCups.GetInstance();
        _CollectedCups.PlayerTransform = transform;
        finished = false;
        CollectCups.FinishLine += FinishMode;
        CollectCups.LevelEnd += LevelEndMode;
    }
}
