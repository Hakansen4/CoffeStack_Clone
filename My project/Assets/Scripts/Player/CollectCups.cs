using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCups : MonoBehaviour
{
    private CollectedCups _CollectedCups;
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
                if (other.GetComponent<FinishHandBarrier>() != null)
                    other.GetComponent<FinishHandBarrier>().Move();

                if (GetComponent<Cup>() != null)
                    _CollectedCups.Crash(GetComponent<Cup>());

                if (other.GetComponent<HandBarrier>() != null)
                    other.GetComponent<HandBarrier>().Move();

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
        else if(other.CompareTag("LevelEnd"))
        {
            Debug.Log(_CollectedCups.Money());
            Debug.Log(_Money.GetMoney());
            //int x = _CollectedCups.Money() + _Money.GetMoney();
        }
    }
}
