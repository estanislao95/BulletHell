using System;
using System.Collections.Generic;
using UnityEngine;

public class Model : Ilife
{
    int _life = FlyweightPointer.Player.maxLife;
    Transform _transform;
    float _speed = FlyweightPointer.Player.speed;
    public event Action hit;
    public event Action dead;

    float miny;
    float maxy;
    float minx;
    float maxx;

    public Model(Transform transform,float _miny, float _maxy, float _minx, float _maxx)
    {
        _transform = transform;

        miny = _miny;
        maxy = _maxy;
        minx = _minx;
        maxx = _maxx;
    }



    public void Move(float h, float v)
    {
        var dir = _transform.up * v;
        dir += _transform.right * h;
        dir.z = 0;

        _transform.position = pos(_transform.position) + dir * _speed * Time.deltaTime;



    }

    public Vector3 pos(Vector3 ae)
    {
        if (ae.x >= maxx) ae = new Vector3(maxx, ae.y, ae.z);
        if (ae.x <= minx) ae = new Vector3(minx, ae.y, ae.z);
        if (ae.y >= maxy) ae = new Vector3(ae.x, maxy, ae.z);
        if (ae.y <= miny) ae = new Vector3(ae.x, miny, ae.z);
        return ae;
    }


    public void Damage(int dmg)
    {
        _life -= dmg;

        hit?.Invoke();

        if (_life <= 0)
            Debug.Log("GAME OVER");
    }
    

    public void Dead()
    {
        dead?.Invoke();
    }

}
