using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class CustomTankSetup : ITankSetup
{
    private CannonObject _cannon = Resources.Load("Tanks/Cannons/Cannon1") as CannonObject;
    private BodyObject _body = Resources.Load("Tanks/Bodies/Body1") as BodyObject;
    private TowerObject _tower = Resources.Load("Tanks/Towers/Tower1") as TowerObject;
    
    public CannonObject Cannon
    {
        get => _cannon;
        set => _cannon = value;
    }
    public BodyObject Body
    {
        get => _body;
        set => _body = value;
    }

    public TowerObject Tower
    {
        get => _tower;
        set => _tower = value;
    }

    public CustomTankSetup()
    {
        Debug.Log($"{Cannon.name} , {Body.name} , {Tower.name}");
    }

    public void ChangeDetail(CannonObject cannon)
    {
        Cannon = cannon;
        Debug.Log(Cannon);
    }
    
    public void ChangeDetail(BodyObject body)
    {
        Body = body;
        Debug.Log(Body);
    }
    
    public void ChangeDetail(TowerObject tower)
    {
        Tower = tower;
        Debug.Log(Tower);
    }

}


