using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cup : MonoBehaviour
{
    private Transform ConnectedCup;

    public void Connect(Transform _ConnectedCup)
    {
        ConnectedCup = _ConnectedCup;
    }
    public void Movement()
    {
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, ConnectedCup.position.x, Time.deltaTime * 20),
            ConnectedCup.position.y,
            ConnectedCup.position.z + 1
            );
    }
    public void Throw()
    {
        transform.DOMove(new Vector3(Random.Range(-4, 4), transform.position.y, transform.position.z + 4), 1);
    }
}