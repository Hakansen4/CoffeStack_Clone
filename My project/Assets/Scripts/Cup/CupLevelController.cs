using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupLevelController 
{
    private int Level;
    private GameObject _Plate;
    private MeshRenderer _Mesh;
    Material C;
    public CupLevelController(GameObject Plate,MeshRenderer Mesh,Material B)
    {
        Level = 0;
        _Plate = Plate;
        _Mesh = Mesh;
        C = B;
    }
    public void AddCoffee()
    {
        Material[] mats = _Mesh.materials;
        mats[1] = C;
        _Mesh.materials = mats;
    }
    public void AddPlate()
    {
        _Plate.SetActive(true);
    }
    public void LevelUp()
    {
        if (Level != 2)
            Level++;
        Debug.Log("New Level =" + Level);
    }
}
