using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View
{
    string hit;
    string dead;

    public View(string _hit, string _dead)
    {
        hit = _hit;
        dead = _dead;
    }

    public void Hit()
    {
        AudioManager.instance.Play(hit);
    }

    public void Dead()
    {
        AudioManager.instance.Play(dead);
    }
}
