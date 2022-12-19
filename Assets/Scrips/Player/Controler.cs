using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler
{
    Model _model;

    Cannons _cannon;
    
    public Controler(Model model, Cannons cannon)
    {
        _model = model;
        _cannon = cannon;
    }


    public void ArtificialUpdate()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        if (h != 0 || v != 0)
            _model.Move(h, v);

        if (Input.GetKey(KeyCode.Space))
        {
            _cannon.Shoot();
        }
    }
}
