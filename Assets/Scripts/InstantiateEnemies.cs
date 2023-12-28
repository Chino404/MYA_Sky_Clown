using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemies : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] instantiatePoint;
    
    void Start()
    {
        InstantiateEnemy();
    }
    
    void InstantiateEnemy()
    {
        foreach (var item in instantiatePoint)
        {
            Instantiate(enemy, item.position, item.rotation);
        }
    }
}
