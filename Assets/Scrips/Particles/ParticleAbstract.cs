using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ParticleAbstract : MonoBehaviour, IFactoried<ParticleAbstract>
{
    protected Factory<ParticleAbstract> _referenceBack;
    [SerializeField] protected ParticleSystem particles;

    [SerializeField] protected float _lifeMaxTime = 2;
    [SerializeField] protected float _lifeTimer = 0;

    public virtual void Activated()
    {

    }

    public virtual void Deactivated()
    {
        _referenceBack.ReturnObject(this);
    }

    public virtual void Prepare()
    {
        _lifeTimer = _lifeMaxTime;
    }

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
    public void Create(Factory<ParticleAbstract> op)
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
