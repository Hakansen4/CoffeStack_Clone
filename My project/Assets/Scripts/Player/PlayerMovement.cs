using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement 
{
    public static event Action GameEnded;

    private Transform PlayerTransform;
    private bool Finished;
    private float ForwardMovementSpeed;
    private float HorizontalMovementSpeed;
    private PlayerData _playerData;
    float horizontalValue;
    public PlayerMovement(Transform _PlayerTransform)
    {
        PlayerTransform = _PlayerTransform;
        _playerData = Resources.Load("PlayerData/Player") as PlayerData;
        ForwardMovementSpeed = _playerData.ForwardSpeed;
        HorizontalMovementSpeed = _playerData.HorizontalSpeed;
        Finished = false;
    }
    public void Move()
    {
        if (!Finished)
            horizontalValue = Input.GetAxis("Horizontal");
        var vec = PlayerTransform.position;
        var pos = vec += new Vector3(HorizontalMovementSpeed * Time.deltaTime * horizontalValue, 0, 0);
        pos.x = Mathf.Clamp(pos.x, -4.8f, 4);
        PlayerTransform.position = pos;
        PlayerTransform.Translate(0, 0, ForwardMovementSpeed * Time.deltaTime);
    }
    public void Finish()
    {
        horizontalValue = 0;
        Finished = true;
        ForwardMovementSpeed = 3;
        PlayerTransform.DOMoveX(0, 1);
    }
    public void LevelEnd(float ManagerMoney,float CupsMoney,Transform Hand)
    {
        ForwardMovementSpeed = 0;
        Hand.DORotate(new Vector3(0, 0, -114), 1);
        PlayerTransform.DOMoveY((ManagerMoney / 5), 5).OnComplete(GameEnd);
    }
    private void GameEnd()
    {
        GameEnded?.Invoke();
    }
}
