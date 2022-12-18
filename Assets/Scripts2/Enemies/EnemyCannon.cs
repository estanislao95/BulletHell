using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannon : MonoBehaviour
{
    public void Shoot(ProyectileType type)
    {
        ProyectileManager.instance.SpawnProyectile(transform, type);
    }
}
