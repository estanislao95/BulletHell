using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback_Movement : IMovement
{
    float timer = 0;
    float _maxTime;

    public delegate void ReturnStrategy();
    ReturnStrategy _back;

    CharacterAnimator _anim;
    public Knockback_Movement(ReturnStrategy back, float maxTime = 1)
    {
        _maxTime = maxTime;
        _back = back;
    }
    public void Move()
    {
        _anim.Hurt();

        timer += Time.deltaTime;

        if (timer > _maxTime)
        {
            _back();
            _anim.Fine();
        }
    }

    public void SetTimer(float t)
    {
        
    }

    public float GetTimer()
    {
        return 0;
    }

    public void SetAnim(CharacterAnimator anim)
    {
        _anim = anim;
    }
}
