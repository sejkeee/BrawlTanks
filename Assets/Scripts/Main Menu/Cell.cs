using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.Main_Menu;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Cell : MonoBehaviour, ICell
{
    public static UnityEvent CellClicked = new UnityEvent();
    
    [SerializeField] private IItem _item;

    public Sprite Icon => _item?.Icon;

    public IItem Item
    {
        set => _item = value;
    }
    
    public bool Locked { get; set; }

    public IItem GetItem() => _item;


    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnCellClick);
    }
    
    
    
    public void SetIcon()
    {
        if(Icon != null) GetComponent<Image>().sprite = Icon;
    }

    public void OnCellClick()
    {
        var itemObj = _item.GetType();
        print(itemObj);

        if (itemObj == typeof(CannonObject)) SetupTank.CurrentSetup.ChangeDetail(_item as CannonObject);
        else if(itemObj == typeof(TowerObject)) SetupTank.CurrentSetup.ChangeDetail(_item as TowerObject);
        else if(itemObj == typeof(BodyObject)) SetupTank.CurrentSetup.ChangeDetail(_item as BodyObject);
        
        
        CellClicked?.Invoke();
    }
}
