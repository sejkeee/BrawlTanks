using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public enum MyItem
    {
        TowerObject,
        CannonObject,
        BodyObject
    };

    public MyItem DropDown = MyItem.BodyObject;
    [SerializeField] private List<Cell> _cells = new List<Cell>();

    private void Start()
    {
        _cells.Clear();
        _cells = GetComponentsInChildren<Cell>().ToList();

        if(DropDown == MyItem.TowerObject)  SetAllCells(Resources.LoadAll<TowerObject>("Tanks/Towers/") as IItem[]);
        else if(DropDown == MyItem.CannonObject)  SetAllCells(Resources.LoadAll<CannonObject>("Tanks/Cannons/") as IItem[]);
        else if(DropDown == MyItem.BodyObject)  SetAllCells(Resources.LoadAll<BodyObject>("Tanks/Bodies/") as IItem[]);
    }

    private void SetAllCells(IItem[] obj)
    {
        var i = 0;
        foreach (var s in obj)
        {
            _cells[i].Item = s;
            _cells[i].SetIcon();
            
            i++;
        }
        
        /*foreach (var cell in _cells)
        {
            cell.gameObject.SetActive(cell.sprite != null);
        }*/
    }

    public void ClosePopup()
    {
        gameObject.SetActive(false);
    }
}

