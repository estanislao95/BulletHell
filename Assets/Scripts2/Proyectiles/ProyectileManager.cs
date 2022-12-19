using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Santiago R. D'Angelo
public class ProyectileManager : ProyectileManagerAbstract
{

    public static ProyectileManager instance; 

    [SerializeField]
    ProyectileData[] _proyectileObject; 
    Dictionary<ProyectileType, ProyectileData> _dictionary = new Dictionary<ProyectileType, ProyectileData>(); 

    private void Awake() 
    {
        instance = this;


        for (int i = 0; i < _proyectileObject.Length; i++)
        {
            _proyectileObject[i].factory = FactoryBuild(_proyectileObject[i].Drop, TurnOn, TurnOff, _proyectileObject[i].stock);
            _dictionary.Add(_proyectileObject[i].type, _proyectileObject[i]);
        }


    }


    public void SpawnProyectile(Transform t, ProyectileType type) 
    {
        AbstractSpawnProyectile(t, _dictionary[type].factory);
    }

    public Factory<ProyectileAbstract> AddToPool(ProyectileAbstract bullet, ProyectileType type) 
    {
        return AbstractAddToPool(bullet, _dictionary[type].factory);
    }


}

public enum ProyectileType
{
    straight,
    fast
}

[System.Serializable]
public struct ProyectileData 
{
    public ProyectileType type;
    public ProyectileAbstract proyectileObject;
    public Factory<ProyectileAbstract> factory;
    public int stock;

    public ProyectileAbstract Drop()
    {
        ProyectileAbstract bullet = GameObject.Instantiate(proyectileObject);

        return bullet;
    }
}
