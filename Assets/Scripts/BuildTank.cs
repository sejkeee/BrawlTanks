using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTank : MonoBehaviour
{
    private CustomTankSetup _currentSetup;
    
    [SerializeField] private Transform _bodyPoint;
    [SerializeField] private Transform _towerPoint;
    [SerializeField]  private Transform _cannonPoint;

    private GameObject _bodyInstance;
    private GameObject _towerInstance;
    private GameObject _cannonInstance;
    
    private void Start()
    {
        _currentSetup = SetupTank.CurrentSetup;
        if (_currentSetup == null) _currentSetup = new CustomTankSetup();
        SetTank();

    }
    
    private void SetTank()
    {
        _bodyInstance = Instantiate(_currentSetup.Body.Main, _bodyPoint.position, _bodyPoint.rotation);
        _towerInstance = Instantiate(_currentSetup.Tower.Main, _towerPoint.position, _towerPoint.rotation);
        _cannonInstance = Instantiate(_currentSetup.Cannon.Main, _cannonPoint.position, _towerPoint.rotation);

        _bodyInstance.transform.SetParent(_bodyPoint);
        _towerInstance.transform.SetParent(_towerPoint);
        _cannonInstance.transform.SetParent(_cannonPoint);
    }
}
