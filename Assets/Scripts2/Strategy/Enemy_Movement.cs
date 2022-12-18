using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy_Movement : IMovement
{
    public delegate void ShootMethod(ProyectileType type);

    protected ProyectileType _type = ProyectileType.straight;

    protected ShootMethod _shoot;
    public void ShotType(ProyectileType type)
    {
        _type = type;
    }
    public virtual void Move()
    {
        //
    }
}
