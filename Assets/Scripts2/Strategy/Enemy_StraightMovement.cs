using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_StraightMovement : Enemy_Movement
{

    Transform _transform;
    float _speed;
    Vector3 _dir;

    float timer = 0;
    float _frequency;
    public Enemy_StraightMovement(Transform transform, Vector3 dir, ShootMethod shoot, float speed = 1, float frequency = 0.5f)
    {
        _transform = transform;
        _speed = speed;
        _dir = dir;
        _shoot = shoot;
        _frequency = frequency;
    }

    public override void Move()
    {
        _transform.position += _dir * _speed * Time.deltaTime;

        timer += Time.deltaTime;
        if (timer > _frequency)
        {
            timer = 0;
            _shoot(_type);
        }
    }
}
