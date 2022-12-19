using System;

using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlayerLife, IObservableFloat
{
    Model _model;
    View _view;
    Controler _controler;
    [SerializeField] int life;

    
    [SerializeField]
    string hit, dead;
    [SerializeField]
    float MaxIframes;

    [SerializeField]
    List<IObserverFloat> _allObservers = new List<IObserverFloat>();

    [SerializeField] PlayerAnimator _anim;
    [SerializeField] Cannons cannons;

    void Start()
    {
        GameManager.Instance.player = this;
        life = FlyweightPointer.Player.maxLife;

        _model = new Model(life, transform, _allObservers, MaxIframes);
        _view = new View(hit, dead, _anim);
        _controler = new Controler(_model, cannons);

        _model.hit += _view.Hit;
        _model.dead += _view.Dead;
        _model.move += _view.Move;
        _model.stop += _view.Stop;
        _model.NotifyToObserver(life);
        cannons.shoot += _view.Shoot;
    }
    private void Update()
    {
        _controler.ArtificialUpdate();
    }

    public void Damage(int dmg)
    {
        _model.Damage(dmg);
    }

    public void Dead()
    {
        //unused
    }

    public void Subscribe(IObserverFloat obs)
    {
        if (!_allObservers.Contains(obs))
            _allObservers.Add(obs);
    }

    public void Unsubscribe(IObserverFloat obs)
    {
        if (!_allObservers.Contains(obs))
            _allObservers.Remove(obs);
    }

    public void NotifyToObserver(float life)
    {
        _model.NotifyToObserver(life);
    }


}
