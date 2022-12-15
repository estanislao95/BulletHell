using System;

using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, Ilife
{
    Model _model;
    View _view;
    Controler _controler;


    [SerializeField]
    float miny, maxy, minx, maxx;
    
    [SerializeField]
    string hit, dead;

    void Start()
    {
        _model = new Model(transform, miny, maxy, minx, maxx);
        _view = new View(hit, dead);
        _controler = new Controler(_model);

        _model.hit += _view.Hit;
        _model.dead += _view.Dead;
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

    }




}
