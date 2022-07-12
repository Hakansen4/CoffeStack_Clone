using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement 
{
    private Transform PlayerTransform;
    private bool Finished;
    private float ForwardMovementSpeed = 6;
    private float HorizontalMovementSpeed = 5;
    float horizontalValue;
    public PlayerMovement(Transform _PlayerTransform)
    {
        PlayerTransform = _PlayerTransform;
        Finished = false;
    }
    public void Move()
    {
        if (!Finished)
            horizontalValue = Input.GetAxis("Horizontal");
        PlayerTransform.Translate(new Vector3(horizontalValue * Time.deltaTime * HorizontalMovementSpeed
                                , 0, ForwardMovementSpeed * Time.deltaTime));
    }
    public void Finish()
    {
        horizontalValue = 0;
        Finished = true;
        ForwardMovementSpeed = 3;
        PlayerTransform.position = new Vector3(0, PlayerTransform.position.y, PlayerTransform.position.z);
    }
}
