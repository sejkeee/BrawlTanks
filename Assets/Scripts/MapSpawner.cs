using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    private float _blockMetr = 2f;

    [SerializeField] private List<GameObject> GroundBlocks
        = new List<GameObject>();
    [SerializeField] private List<GameObject> OutsideBlocks
        = new List<GameObject>();
        
    
    private MapCreator _mapCreator;

    private void Start()
    {
        _mapCreator = MapCreator.GetMap();
        SpawnMap();
    }
    
    
    private void SpawnMap()
    {
        foreach (var blockPos in _mapCreator.Ground)
        {
            if(blockPos.y > 0)    Instantiate(OutsideBlocks[Random.Range(0, OutsideBlocks.Count)], blockPos*_blockMetr, Quaternion.identity);

            else Instantiate(GroundBlocks[Random.Range(0, GroundBlocks.Count)], blockPos*_blockMetr, Quaternion.identity);
        }
    }
}
