using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedCups
{
    private static CollectedCups instance;
    private List<Cup> _CollectedCups;
    public Transform PlayerTransform;
    private CollectedCups()
    {
        _CollectedCups = new List<Cup>();
    }
    public static CollectedCups GetInstance()
    {
        if(instance == null)
        {
            instance = new CollectedCups();
        }
        return instance;
    }
    public void AddCup(Cup NewCup)
    {
        _CollectedCups.Add(NewCup);
        if (_CollectedCups.Count == 1)
            NewCup.Connect(PlayerTransform);
        else
            NewCup.Connect(_CollectedCups[_CollectedCups.Count - 2].gameObject.transform);
        NewCup.gameObject.AddComponent<CollectCups>();
    }
    public void MoveCollectedCups()
    {
        foreach (var item in _CollectedCups)
        {
            item.Movement();
        }
    }
}
