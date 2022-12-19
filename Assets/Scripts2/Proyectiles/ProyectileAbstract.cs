using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProyectileAbstract : MonoBehaviour, IFactoried<ProyectileAbstract>, Ilife
{
    protected Factory<ProyectileAbstract> _referenceBack;

    //[SerializeField] protected IMovement[] _strategies;
    [SerializeField] protected IMovement _chosenStrategy;

    [SerializeField] protected int _damage = 1;
    [SerializeField] protected float _speed = 1;
    [SerializeField] protected int _maxLife = 1;
    [SerializeField] protected int _health = 1;

    [SerializeField] protected float _lifeMaxTime = 2;
    [SerializeField] protected float _lifeTimer = 0;

    [SerializeField] protected ParticleType _particletype;
    public virtual void Activated()
    {
    }

    public virtual void Deactivated()
    {
        Debug.Log("aaaaaaaaaaaaaaaaaaaaa");
        _referenceBack.ReturnObject(this);
    }

    public virtual void Prepare()
    {
        _lifeTimer = _lifeMaxTime;
        _health = _maxLife;
    }

    #region Strategy
    protected virtual void StrategyMove(IMovement movement)
    {
        movement.Move();
    }

    protected virtual void ChangeStrategy(IMovement movement)
    {
        _chosenStrategy = movement;
    }
    #endregion

    #region Damage
    public virtual void Damage(int life)
    {
        if (_health <= 0) return;
    
        ParticleManager.instance.SpawnParticle(transform, _particletype);
        _health -= life;
        if (_health <= 0)
        {
            Dead();
        }
    }

    public virtual void Dead()
    {
        Deactivated();
    }
    #endregion

    #region Lifetime
    protected virtual void lifeTimeCount(float time)
    {
        _lifeTimer -= time;
        if (_lifeTimer <= 0)
            lifeTimeOver();
    }

    protected virtual void lifeTimeOver()
    {
        Deactivated();
    }
    #endregion

    #region Factory
    public void Create(Factory<ProyectileAbstract> op)
    {
        _referenceBack = op;
        Activated();
    }

    public void TurnOff()
    {
        gameObject.SetActive(false);
    }

    public void TurnOn()
    {
        gameObject.SetActive(true);
        Activated();
    }
    #endregion
}
