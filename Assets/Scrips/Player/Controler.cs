using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler
{
    Model _model;
    
    public Controler(Model model)
    {
        _model = model;
    }


    public void ArtificialUpdate()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        if (h != 0 || v != 0)
            _model.Move(h, v);
    }
}
