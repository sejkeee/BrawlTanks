using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> Enemies = new List<Enemy>();

    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        var enemy = Instantiate(Enemies[0], transform.position, transform.rotation);
    }
}
