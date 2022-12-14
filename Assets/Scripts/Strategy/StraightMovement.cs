using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMovement : IMovement
{
    //public delegate void Shoot();
    //Shoot _shootMethod;

    Transform _transform;
    float _speed;
    Vector3 _dir;
    public StraightMovement(Transform transform, Vector3 dir, float speed = 1)
    {
        _transform = transform;
        _speed = speed;
        _dir = dir;
    }
    public void Move()
    {
        _transform.position += _dir * _speed * Time.deltaTime;
    }
}
