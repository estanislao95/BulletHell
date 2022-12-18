using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMovement : IMovement
{

    Transform _transform;
    float _speed;
    Vector3 _dir;
    public StraightMovement(Transform transform, Vector3 dir, float speed = 1)
    {
        _transform = transform;
        _speed = speed;
        _dir = dir;
    }

    #region Timer
    public void SetTimer(float t)
    {
        
    }
    public float GetTimer()
    {
        return 0;
    }
    #endregion

    public void Move()
    {
        _transform.position += _dir * _speed * Time.deltaTime;
    }

    public void SetAnim(CharacterAnimator anim)
    {
    }
}
