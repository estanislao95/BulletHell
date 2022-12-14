using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbstract : MonoBehaviour, Ilife
{
    //[SerializeField] protected IMovement[] _strategies;
    [SerializeField] protected IMovement _chosenStrategy;

    [SerializeField] protected int _damage = 1;
    [SerializeField] protected int _health = 1;
    [SerializeField] protected float _speed = 1;

    [SerializeField] protected ProyectileType _proyectileType;

    #region Damage
    public virtual void Damage(int life)
    {
        _health -= life;
        if (_health <= 0)
        {
            Dead();
        }
    }

    public virtual void Dead()
    {
        Destroy(gameObject);
    }
    #endregion

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


}
