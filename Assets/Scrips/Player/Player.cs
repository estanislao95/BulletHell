using System;

using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPlayerLife
{
    Model _model;
    View _view;
    Controler _controler;


    [SerializeField]
    float miny, maxy, minx, maxx;


    void Start()
    {
        _model = new Model(transform, miny, maxy, minx, maxx);
        _view = new View();
        _controler = new Controler(_model);

        _model.hit += _view.Hit;
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
