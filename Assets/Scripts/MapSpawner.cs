using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    private float _blockMetr = 2f;

    [SerializeField] private List<GameObject> GroundBlocks
        = new List<GameObject>();


    private int[,] _maps;

    private IEnumerator Start()
    {
        _maps = Maps.GetMap();
        yield return StartCoroutine(SpawnMap());
    }

    private IEnumerator SpawnMap()
    {
        for (var i = 0; i < _maps.GetLength(0); i++)
        {
            for (var j = 0; j < _maps.GetLength(1); j++)
            {
                if(_maps[i, j] <= 1)    Instantiate(GroundBlocks[(i+j)%2], new Vector3(i, _maps[i, j], j) * _blockMetr, Quaternion.identity);
                
                else    Instantiate(GroundBlocks[_maps[i, j]], new Vector3(i, 1, j) * _blockMetr, Quaternion.identity);
                    
                yield return null;
            }
        }
    }
}
