using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class ProyectileManagerAbstract : MonoBehaviour
{
    public Factory<ProyectileAbstract> FactoryBuild(Factory<ProyectileAbstract>.FactoryMethod fm, Action<ProyectileAbstract> On, Action<ProyectileAbstract> Off, int stock)
    {
        return new Factory<ProyectileAbstract>(fm, On, Off, stock);
    }
    public void TurnOn(ProyectileAbstract p) //same as proyectile manager
    {
        p.TurnOn();
    }

    public void TurnOff(ProyectileAbstract p) //same as proyectile manager
    {
        p.TurnOff();
    }

    protected void AbstractSpawnProyectile(Transform t, Factory<ProyectileAbstract> factory) //new for PPM, needs different parameters
    {

        //print("shooting " + bullet.ToString());
        var b = factory.GetObject();
        b.Create(factory);
        b.transform.position = t.position;
        b.transform.rotation = t.rotation;

    }

    protected Factory<ProyectileAbstract> AbstractAddToPool(ProyectileAbstract bullet, Factory<ProyectileAbstract> factory)
    {
        factory.ReturnObject(bullet);

        return factory;
    }
}
