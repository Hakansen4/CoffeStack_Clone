using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupLevelController 
{
    private int Level;
    private int Money;
    private GameObject _Plate;
    private MeshRenderer _Mesh;
    Material CoffeeMaterial;
    Material Lvl2Material;
    Material Lvl3Material;
    public CupLevelController(GameObject Plate,MeshRenderer Mesh)
    {
        Level = 0;
        Money = 0;
        _Plate = Plate;
        _Mesh = Mesh;
        LoadMaterials();
    }
    private void LoadMaterials()
    {
        CoffeeMaterial = Resources.Load("Cup_Materials/Coffee_Material") as Material;
        Lvl2Material = Resources.Load("Cup_Materials/Lvl2_Material") as Material;
        Lvl3Material = Resources.Load("Cup_Materials/Lvl3_Material") as Material;
    }
    public void AddCoffee()
    {
        if(Level == 0)
        {
            Material[] mats = _Mesh.materials;
            mats[1] = CoffeeMaterial;
            _Mesh.materials = mats;
            Level++;
            Money++;
        }
    }
    public void AddPlate()
    {
        if(!_Plate.active)
        {
            _Plate.SetActive(true);
            Money++;
        }
    }
    public void LevelUp()
    {
        if (Level <= 2)
        {
            Material[] mats = _Mesh.materials;
            if (Level < 2)
                mats[1] = Lvl2Material;
            else
                mats[1] = Lvl3Material;
            _Mesh.materials = mats;
            Level += 2;
            Money++;
        }
    }
    public int GetMoney()
    {
        return Money;
    }
}
