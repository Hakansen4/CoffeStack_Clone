using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Collected"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().FinishMode();
        }
    }
}
