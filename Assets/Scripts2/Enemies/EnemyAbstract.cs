using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Santiago R. D'Angelo
public abstract class EnemyAbstract : MonoBehaviour, IFactoried<EnemyAbstract>, Ilife
{
    protected Factory<EnemyAbstract> _referenceBack;
    //[SerializeField] protected IMovement[] _strategies;
    [SerializeField] protected IMovement _chosenStrategy;

    [SerializeField] protected int _damage = 1;
    [SerializeField] protected int _health = 1;
    [SerializeField] protected float _speed = 1;

    [SerializeField] protected ProyectileType _proyectileType;

    protected EnemyHandler _eh;
    public virtual void Activated()
    {
        
    }

    public virtual void Deactivated()
    {
        _referenceBack.ReturnObject(this);

        if (_eh != null)
            returnToHandler(_eh);
    }

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
        Deactivated();
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

    #region Factory
    public void Create(Factory<EnemyAbstract> op)
    {
        _referenceBack = op;
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

    #region Wave
    //para cuando queremos hacer olas basadas en la cantidad de enemigos destruidos, con esto nos aseguramos que mataron a todos los enemigos.
    //capaz simplemente un int seria mejor.

     public void assignHandler(EnemyHandler eh)
     {
     _eh = eh;
     }

    public void returnToHandler(EnemyHandler eh)
    {
    eh.EnemyKilled(this);
    }

    
    #endregion

}
