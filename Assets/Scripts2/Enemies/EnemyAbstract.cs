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

    [SerializeField] EnemyCannon[] _cannons;

    protected EnemyHandler _eh;
    public int DeadPoints;
    public virtual void Activated()
    {
        
    }

    public virtual void Deactivated()
    {
        _referenceBack.ReturnObject(this);
        GameManager.Instance.addpoints(DeadPoints);
        if (_eh != null)
            ReturnToHandler(_eh);
    }

    #region Shoot
    public void Shoot(ProyectileType type)
    {
        foreach (var item in _cannons)
        {
            item.Shoot(type);
        }
    }
    #endregion

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
    //A CONSIDERAR: Potencialmente vamos a querer que enemyHandler sea un instance. Pero esto significaria que todos los enemigos al morir lo llamarian,
    //y capaz no queramos eso. Por eso, por ahora, lo dejamos asi.
     public void AssignHandler(EnemyHandler eh)
     {
     _eh = eh;
     }

    public void ReturnToHandler(EnemyHandler eh)
    {
    eh.EnemyKilled(this);
    }

    
    #endregion

}
