using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_DiagonalMovement : Enemy_Movement
{
    Transform _transform;
    Vector2 _speed;

    float timer = 0;
    float _frequency;

    float dir = 1;
    public Enemy_DiagonalMovement(Transform transform, ShootMethod shoot, Vector2 speed, float frequency = 0.5f)
    {
        _transform = transform;
        _speed = speed;
        _shoot = shoot;
        _frequency = frequency;
    }

    public override void Move()
    {
        _transform.position += -_transform.up * _speed.y * Time.deltaTime;

        _transform.position += _transform.right * dir * _speed.x * Time.deltaTime;

        timer += Time.deltaTime;

        if (_anim != null)
            _anim.Move();

        if (timer > _frequency)
        {
            timer = 0;
            _shoot(_type);
            dir = -dir;

            _anim.Shoot();
        }
    }
}
