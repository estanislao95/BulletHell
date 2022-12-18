using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy_Movement : IMovement
{
    public delegate void ShootMethod(ProyectileType type);

    protected ProyectileType _type = ProyectileType.straight;

    protected ShootMethod _shoot;

    protected CharacterAnimator _anim;
    public void ShotType(ProyectileType type)
    {
        _type = type;
    }
    public virtual void Move()
    {
        //
    }


    public void SetAnim(CharacterAnimator anim)
    {
        _anim = anim;
    }

    #region Timer
    public virtual void SetTimer(float t)
    {

    }
    public virtual float GetTimer()
    {
        return 0;
    }

    #endregion
}
