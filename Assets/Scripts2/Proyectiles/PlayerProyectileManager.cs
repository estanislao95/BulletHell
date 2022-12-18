using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Santiago R. D'Angelo
public class PlayerProyectileManager : ProyectileManagerAbstract
{
    
    public static PlayerProyectileManager instance; 

    [SerializeField]
    PlayerProyectileData[] _proyectileObject; 
    Dictionary<PlayerProyectileType, PlayerProyectileData> _dictionary = new Dictionary<PlayerProyectileType, PlayerProyectileData>(); 

    private void Awake() 
    {
        instance = this;


        for (int i = 0; i < _proyectileObject.Length; i++)
        {
            _proyectileObject[i].factory = FactoryBuild(_proyectileObject[i].Drop, TurnOn, TurnOff, _proyectileObject[i].stock);
            _dictionary.Add(_proyectileObject[i].type, _proyectileObject[i]);
        }


    }


    public void SpawnProyectile(Transform t, PlayerProyectileType type) 
    {
        AbstractSpawnProyectile(t, _dictionary[type].factory);
    }

    public Factory<ProyectileAbstract> AddToPool(ProyectileAbstract bullet, PlayerProyectileType type)  
    {
        return AbstractAddToPool(bullet, _dictionary[type].factory);
    }


}

public enum PlayerProyectileType 
{
    straight,
    fire,
    Lazer,
    rocket
}

[System.Serializable]
public struct PlayerProyectileData 
{
    public PlayerProyectileType type;
    public ProyectileAbstract proyectileObject;
    public Factory<ProyectileAbstract> factory;
    public int stock;

    public ProyectileAbstract Drop()
    {
        ProyectileAbstract bullet = GameObject.Instantiate(proyectileObject);

        return bullet;
    }
}
