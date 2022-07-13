using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    MoneyManager _MoneyManager;
    private void Awake()
    {
        _MoneyManager = MoneyManager.GetInstance();
    }
    private void Update()
    {
        //int x = _MoneyManager.GetMoney() + GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().GetMoney();
        //Debug.Log(x);
    }
}
