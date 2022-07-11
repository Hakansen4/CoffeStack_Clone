using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCups : MonoBehaviour
{
    private CollectedCups _CollectedCups;
    private void Start()
    {
        _CollectedCups = CollectedCups.GetInstance();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Cup"))
        {
            other.tag = "Collected";
            _CollectedCups.AddCup(other.GetComponent<Cup>());
        }
        else if(other.CompareTag("Barrier"))
        {
            if (GetComponent<Cup>() != null)
                _CollectedCups.Crash(GetComponent<Cup>());
        }
        else if(other.CompareTag("Coffee"))
        {
            if (GetComponent<Cup>() != null)
                _CollectedCups.AddCoffee(GetComponent<Cup>());
        }
        else if(other.CompareTag("Plate"))
        {
            if (GetComponent<Cup>() != null)
                _CollectedCups.AddPlate(GetComponent<Cup>());
        }
        else if(other.CompareTag("LevelUp"))
        {
            if (GetComponent<Cup>() != null)
                _CollectedCups.LevelUp(GetComponent<Cup>());
        }
    }
}
