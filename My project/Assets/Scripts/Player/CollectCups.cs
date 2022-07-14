using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CollectCups : MonoBehaviour
{
    public static event Action FinishLine;
    public static event Action<float,float> LevelEnd;
    public static event Action<float> AddMoney;

    private CollectedCups _CollectedCups;
    [SerializeField] private Player _Player;
    private MoneyManager _Money;
    private bool collided;
    private void Start()
    {
        collided = false;
        _CollectedCups = CollectedCups.GetInstance();
        _Money = MoneyManager.GetInstance();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Cup"))
        {
            other.tag = "Collected";
            _CollectedCups.AddCup(other.GetComponent<Cup>());
        }
        else if(other.CompareTag("Barrier"))
        {
            if(!collided)
            {
                if(other.GetComponent<FinishHandBarrier>() != null)
                {
                    other.GetComponent<FinishHandBarrier>().Move();
                    AddMoney?.Invoke(GetComponent<Cup>().Level.GetMoney());
                }
                

                if (GetComponent<Cup>() != null)
                    _CollectedCups.Crash(GetComponent<Cup>());

                other.GetComponent<HandBarrier>()?.Move();

                collided = true;
            }
        }
        else if(other.CompareTag("Coffee"))
        {
            if (GetComponent<Cup>() != null)
                _CollectedCups.AddCoffee(GetComponent<Cup>());
        }
        else if(other.CompareTag("Plate"))
        {
            if (GetComponent<Cup>() != null)
                _CollectedCups.AddPlate(GetComponent<Cup>());
        }
        else if(other.CompareTag("LevelUp"))
        {
            if (GetComponent<Cup>() != null)
                _CollectedCups.LevelUp(GetComponent<Cup>());
        }
        else if(other.CompareTag("FinishLine"))
        {
            FinishLine?.Invoke();
        }
        else if(other.CompareTag("LevelEnd"))
        {
            LevelEnd?.Invoke(_Money.GetMoney(), _Player.GetMoney());
        }
    }
}
