using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager
{
    private static MoneyManager instance;

    private int Money;
    private MoneyManager()
    {
        Money = 0;
    }
    public static MoneyManager GetInstance()
    {
        if (instance == null)
        {
            instance = new MoneyManager();
        }
        return instance;
    }
    public int GetMoney()
    {
        return Money;
    }
    public void AddMoney(int _Money)
    {
        Money += _Money;
    }
}
