using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View
{
    string hit;
    string dead;

    PlayerAnimator _anim;

    public View(string _hit, string _dead, PlayerAnimator anim)
    {
        hit = _hit;
        dead = _dead;
        _anim = anim;
    }

    public void Shoot()
    {
        _anim.Shoot();
    }
    public void Hit()
    {
        AudioManager.instance.Play(hit);
        _anim.Hurt();
    }

    public void Dead()
    {
        AudioManager.instance.Play(dead);
        _anim.Dead();
    }

    public void Stop()
    {
        _anim.Stop();
    }

    public void Move()
    {
        _anim.Move();
    }
}
