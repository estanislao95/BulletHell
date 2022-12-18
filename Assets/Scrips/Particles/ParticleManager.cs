using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager instance;

    [SerializeField]
    ParticleData[] _ParticleObject;
    Dictionary<ParticleType, ParticleData> _dictionary = new Dictionary<ParticleType, ParticleData>();


    private void Awake()
    {
        instance = this;
        for (int i = 0; i < _ParticleObject.Length; i++)
        {
            _ParticleObject[i].factory = FactoryBuild(_ParticleObject[i].Drop, TurnOn, TurnOff, _ParticleObject[i].stock);
            _dictionary.Add(_ParticleObject[i].type, _ParticleObject[i]);
        }
    }


    public Factory<ParticleAbstract> FactoryBuild(Factory<ParticleAbstract>.FactoryMethod fm, Action<ParticleAbstract> On, Action<ParticleAbstract> Off, int stock)
    {
        return new Factory<ParticleAbstract>(fm, On, Off, stock);
    }
    public void TurnOn(ParticleAbstract p) //same as proyectile manager
    {
        p.TurnOn();
    }

    public void TurnOff(ParticleAbstract p) //same as proyectile manager
    {
        p.TurnOff();
    }

    public void SpawnParticle(Transform t, ParticleType type) //new for PPM, needs different parameters
    {

        var b = _dictionary[type].factory.GetObject();
        b.transform.position = t.position;
        b.transform.rotation = t.rotation;
        b.Create(_dictionary[type].factory);
        b.Prepare();
        b.Activated();
    }
    
    public Factory<ParticleAbstract> AddToPool(ParticleAbstract bullet, Factory<ParticleAbstract> factory)
    {
        factory.ReturnObject(bullet);

        return factory;
    }




}

public enum ParticleType
{
    standard
}

[System.Serializable]
public struct ParticleData
{
    public ParticleType type;
    public ParticleAbstract ParticleObject;
    public Factory<ParticleAbstract> factory;
    public int stock;

    public ParticleAbstract Drop()
    {
        ParticleAbstract bullet = GameObject.Instantiate(ParticleObject);

        return bullet;
    }
}