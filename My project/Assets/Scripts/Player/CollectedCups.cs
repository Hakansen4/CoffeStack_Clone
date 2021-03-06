using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedCups
{
    private static CollectedCups instance;
    public List<Cup> _CollectedCups;
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
    public void Crash(Cup _CrashedCup)
    {
        int index = _CollectedCups.IndexOf(_CrashedCup);
        if(index != _CollectedCups.Count-1)
        {
            //Delete in middle of the list
            for(int i = _CollectedCups.Count-1;i>index;i--)
            {
                _CollectedCups[i].Throw();
                _CollectedCups[i].tag = "Cup";
                _CollectedCups.RemoveAt(i);
            }
        }
        _CollectedCups.RemoveAt(index);
        _CrashedCup.Kill();
    }
    public void AddCoffee(Cup _Cup)
    {
        _Cup.Level.AddCoffee();
    }
    public void AddPlate(Cup _Cup)
    {
        _Cup.Level.AddPlate();
    }
    public void LevelUp(Cup _Cup)
    {
        _Cup.Level.LevelUp();
    }
    public int Money()
    {
        int _Money = 0;
        foreach (var item in _CollectedCups)
        {
            _Money += item.Level.GetMoney();
        }
        return _Money;
    }
}
