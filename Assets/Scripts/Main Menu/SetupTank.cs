using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class SetupTank : MonoBehaviour
{
    public static CustomTankSetup CurrentSetup;

    [SerializeField] private Transform _bodyPoint;
    [SerializeField] private Transform _towerPoint;
    [SerializeField]  private Transform _cannonPoint;

    [SerializeField] private Button _bodyButton;
    [SerializeField] private Button _towerButton;
    [SerializeField] private Button _cannonButton;

    private GameObject _bodyInstance;
    private GameObject _towerInstance;
    private GameObject _cannonInstance;
    
    private void Start()
    {
        CurrentSetup = new CustomTankSetup();
        CompileDefaultTank();
        
        Cell.CellClicked.AddListener(UpdateSetup);
    }

    private void UpdateSetup()
    {
        Destroy(_bodyInstance);
        Destroy(_towerInstance);
        Destroy(_cannonInstance);

        SetTank();
    }

    private void CompileDefaultTank()
    {
        SetTank();
    }

    private void SetTank()
    {
        _bodyInstance = Instantiate(CurrentSetup.Body.Main, _bodyPoint.position, _bodyPoint.rotation);
        _towerInstance = Instantiate(CurrentSetup.Tower.Main, _towerPoint.position, _towerPoint.rotation);
        _cannonInstance = Instantiate(CurrentSetup.Cannon.Main, _cannonPoint.position, _towerPoint.rotation);
        
        _bodyButton.GetComponent<Image>().sprite = CurrentSetup.Body.Icon;
        _towerButton.GetComponent<Image>().sprite = CurrentSetup.Tower.Icon;
        _cannonButton.GetComponent<Image>().sprite = CurrentSetup.Cannon.Icon;
        
        _bodyInstance.transform.SetParent(transform);
        _towerInstance.transform.SetParent(transform);
        _cannonInstance.transform.SetParent(transform);
    }

}
