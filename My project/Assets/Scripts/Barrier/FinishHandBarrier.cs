using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FinishHandBarrier : MonoBehaviour
{
    public int Money;
    MoneyManager _MoneyManager;
    [SerializeField] private HandBarrierEnum _Barrier;
    public void Move()
    {
        _MoneyManager = MoneyManager.instance;
        if (_Barrier == HandBarrierEnum.Right)
            transform.DOMoveX(transform.position.x + 4, 1);
        else
            transform.DOMoveX(transform.position.x - 4, 1);

        _MoneyManager.AddMoney(Money);
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
