using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Santiago R. D'Angelo
public class ProyectileManager : ProyectileManagerAbstract
{

    public static ProyectileManager instance; //new for PPM

    [SerializeField]
    ProyectileData[] _proyectileObject; //new for PPM, this would be unused.
    Dictionary<ProyectileType, ProyectileData> _dictionary = new Dictionary<ProyectileType, ProyectileData>(); //new for PPM, this would be unused.

    private void Awake() //override this for PPM
    {
        instance = this;


        for (int i = 0; i < _proyectileObject.Length; i++)
        {
            //_proyectileObject[i].factory = new Factory<ProyectileAbstract>(_proyectileObject[i].Drop, TurnOn, TurnOff, _proyectileObject[i].stock);
            _proyectileObject[i].factory = FactoryBuild(_proyectileObject[i].Drop, TurnOn, TurnOff, _proyectileObject[i].stock);
            _dictionary.Add(_proyectileObject[i].type, _proyectileObject[i]);
        }


    }


    public void SpawnProyectile(Transform t, ProyectileType type) //new for PPM, needs different parameters
    {
        AbstractSpawnProyectile(t, _dictionary[type].factory);
    }

    public Factory<ProyectileAbstract> AddToPool(ProyectileAbstract bullet, ProyectileType type)  //new for PPM, needs different parameters
    {
        return AbstractAddToPool(bullet, _dictionary[type].factory);
    }


}

public enum ProyectileType //new one for PPM
{
    straight
}

[System.Serializable]
public struct ProyectileData //new one for PPM
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
