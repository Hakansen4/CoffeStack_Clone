using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager
{
    private static MoneyManager instance;
    private TextMeshProUGUI MoneyText;
    private float Money;
    private float AllMoney;
    private MoneyManager()
    {
        CollectCups.AddMoney += AddMoney;
        AllMoney = 0;
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
    public void AddText(TextMeshProUGUI text)
    {
        MoneyText = text;
    }
    public float GetMoney()
    {
        return Money;
    }
    public void SetAllMoney(float money)
    {
        AllMoney = money;
    }
    public void AddMoney(float _Money)
    {
        Money += _Money;
        AllMoney += _Money;
        MoneyText.text = AllMoney.ToString() + "  $";
    }
}
