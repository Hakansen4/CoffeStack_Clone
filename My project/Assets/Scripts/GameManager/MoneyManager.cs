using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;

    private int Money;
    private void Awake()
    {
        instance = this;
        Money = 0;
    }

    public void AddMoney(int _Money)
    {
        Money += _Money;
    }
}
