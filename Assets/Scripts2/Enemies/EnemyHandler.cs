using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnEnemy(transform, EnemyType.basic);
        }
    }
    public void SpawnEnemy(Transform transform, EnemyType type)
    {
        EnemyManager.instance.SpawnEnemy(transform, type);
    }
}
