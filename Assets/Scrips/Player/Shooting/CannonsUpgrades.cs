using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonsUpgrades : MonoBehaviour, ICannonUpgrades
{
    public static List<ICannonUpgrades> upgrades = new List<ICannonUpgrades>();


    public List<Transform> Points;
    public ProyectileType type;

    private void Awake()
    {
        upgrades.Add(this);
        foreach (Transform point in gameObject.GetComponentInChildren<Transform>())
        {
            Points.Add(point);
        }

    }

    public void shooting()
    {
        foreach (var item in Points)
        {
            ProyectileManager.instance.SpawnProyectile(item, type);
        }

    }

}
