using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HandBarrier : MonoBehaviour
{
    [SerializeField] private HandBarrierEnum _Barrier;
    public void Move()
    {
        if(_Barrier == HandBarrierEnum.Right)
            transform.DOMoveX(transform.position.x + 4, 1);
        else
            transform.DOMoveX(transform.position.x - 4, 1);

        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
enum HandBarrierEnum
{
    Left,
    Right
}
