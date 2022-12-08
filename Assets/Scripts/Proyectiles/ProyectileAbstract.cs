using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProyectileAbstract : MonoBehaviour, IFactoried<ProyectileAbstract>
{
    protected Factory<ProyectileAbstract> _referenceBack;

    [SerializeField] protected IMovement[] _strategies;
    [SerializeField] protected int _chosenStrategy;

    [SerializeField] protected int _damage = 1;
    [SerializeField] protected float _speed = 1;

    #region Factory
    public void Create(Factory<ProyectileAbstract> op)
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
    }
    #endregion
}
