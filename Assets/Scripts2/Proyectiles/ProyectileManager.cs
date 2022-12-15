using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileManager : MonoBehaviour
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
            _proyectileObject[i].factory = new Factory<ProyectileAbstract>(_proyectileObject[i].Drop, TurnOn, TurnOff, _proyectileObject[i].stock);
            _dictionary.Add(_proyectileObject[i].type, _proyectileObject[i]);
        }


    }

    public void TurnOn(ProyectileAbstract p)
    {
        p.TurnOn();
    }

    public void TurnOff(ProyectileAbstract p)
    {
        p.TurnOff();
    }

    public void SpawnProyectile(Transform t, ProyectileType type)
    {
        ProyectileType bullet = type;

        print("shooting " + bullet.ToString());
        var b = _dictionary[bullet].factory.GetObject();
        b.Create(_dictionary[bullet].factory);
        b.transform.position = t.position;
        b.transform.rotation = t.rotation;

    }

    public Factory<ProyectileAbstract> AddToPool(ProyectileAbstract bullet, ProyectileType type)
    {
        _dictionary[type].factory.ReturnObject(bullet);

        return _dictionary[type].factory;
    }


}

public enum ProyectileType
{
    straight
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
