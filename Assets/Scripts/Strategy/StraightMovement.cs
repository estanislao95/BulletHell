using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMovement : IMovement
{
    //public delegate void Shoot();
    //Shoot _shootMethod;

    Transform _transform;
    float _speed;
    public StraightMovement(Transform transform, float speed = 1)
    {
        _transform = transform;
        _speed = speed;
    }
    public void Move()
    {
        _transform.position += (-_transform.up) * _speed * Time.deltaTime;
    }
}
