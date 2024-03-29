using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonsUpgrades : MonoBehaviour, ICannonUpgrades
{
    //public static List<ICannonUpgrades> upgrades = new List<ICannonUpgrades>();


    public List<Transform> Points;
    //public PlayerProyectileType type;

    private void Awake()
    {
        //upgrades.Add(this);
        foreach (Transform point in gameObject.GetComponentInChildren<Transform>())
        {
            Points.Add(point);
        }

    }

    public void shooting(PlayerProyectileType type)
    {
        foreach (var item in Points)
        {
            PlayerProyectileManager.instance.SpawnProyectile(item, type);
        }

    }

}
