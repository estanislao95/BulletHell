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
    [SerializeField] protected int _maxHealth = 1;
    [SerializeField] protected int _health = 1;
    [SerializeField] protected float _speed = 1;

    [SerializeField] protected float _maxIFrames = 0.1f;
    protected bool _invencible;
    protected float _savedTimer = 0;

    [SerializeField] protected ProyectileType _proyectileType;


    [SerializeField] string EnemyHurt, EnemyDie;


    [Header("Outside References")]
    [SerializeField] EnemyCannon[] _cannons;
    [SerializeField] protected CharacterAnimator _anim;


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

    public virtual void Prepare()
    {
        _health = _maxHealth;
        _anim.Prepare();
    }

    public virtual void DefaultStrategy()
    {

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
        if (_invencible) return;

        if (_health <= 0) return;

        _health -= life;




        if (_health <= 0)
        {
            Dead();
            return;
        }
        AudioManager.instance.Play(EnemyHurt);
        _invencible = true;
        _savedTimer = _chosenStrategy.GetTimer();
        ChangeStrategy(new Knockback_Movement(Back, _maxIFrames));
    }

    public virtual void Back()
    {
        DefaultStrategy();
        _chosenStrategy.SetTimer(_savedTimer);
        _invencible = false;
    }

    public virtual void Dead()
    {
        _anim.Dead();
        AudioManager.instance.Play(EnemyDie);
        LootManager.instance.DropLoot(transform);
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
        _chosenStrategy.SetAnim(_anim);
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
