using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement 
{
    private Transform PlayerTransform;

    private float ForwardMovementSpeed = 3;
    private float HorizontalMovementSpeed = 5;
    float horizontalValue;
    public PlayerMovement(Transform _PlayerTransform)
    {
        PlayerTransform = _PlayerTransform;
    }
    public void Move()
    {
        horizontalValue = Input.GetAxis("Horizontal");
        PlayerTransform.Translate(new Vector3(horizontalValue * Time.deltaTime * HorizontalMovementSpeed
                                , 0, ForwardMovementSpeed * Time.deltaTime));
    }
}
