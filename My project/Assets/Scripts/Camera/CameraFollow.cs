using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Charachter;
    public Vector3 distance;
    private bool finished;
    float followSpeed;
    private void Start()
    {
        finished = false;
        followSpeed = 0.1f;
        CollectCups.FinishLine += FinishMode;
        CollectCups.LevelEnd += LevelEnd;
    }
    private void FinishMode()
    {
        if(!finished)
        {
            finished = true;
            followSpeed = 0.03f;
            distance += new Vector3(0, 2, -1);
            transform.Rotate(new Vector3(5, 0, 0));
        }
    }
    private void LevelEnd(float x,float y)
    {
        //i am not gonna use that values there
        distance += new Vector3(0, -4, 2);
    }
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, Charachter.position + distance, followSpeed);
    }
}
