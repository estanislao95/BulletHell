using System;
using System.Collections.Generic;
using UnityEngine;

public class Model : Ilife, IObservableFloat
{
    int _life;
    Transform _transform;
    float _speed = FlyweightPointer.Player.speed;
    public event Action hit;
    public event Action dead;
    List<IObserverFloat> _allObservers = new List<IObserverFloat>();
    float _MaxIframes;
    bool invensivility;
    float timer;

    float miny;
    float maxy;
    float minx;
    float maxx;

    public Model(int life ,Transform transform,float _miny, float _maxy, float _minx, float _maxx, List<IObserverFloat> allObservers, float MaxIframes)
    {
        _life = life;
        _transform = transform;
        _allObservers = allObservers;
        miny = _miny;
        maxy = _maxy;
        minx = _minx;
        maxx = _maxx;
        _MaxIframes = MaxIframes;
    }



    public void Move(float h, float v)
    {
         
        var dir = _transform.up * v;
        dir += _transform.right * h;
        dir.z = 0;

        _transform.position = pos(_transform.position) + dir * _speed * Time.deltaTime;

        if (invensivility)
        {
            timer += Time.deltaTime;
            if (timer >= _MaxIframes)
            {
                invensivility = false;
                timer = 0;
            }

        }

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
        if (invensivility)
            return;
        _life -= dmg;
        invensivility = true;

        Debug.Log(_life);
        hit?.Invoke();
        NotifyToObserver(dmg);
        if (_life <= 0)
            Dead();
    }
    

    public void Dead()
    {
        dead?.Invoke();
        MenuManager.instance.Dead();
    }


    public void Subscribe(IObserverFloat obs)
    {
        if (!_allObservers.Contains(obs))
            _allObservers.Add(obs);
    }

    public void Unsubscribe(IObserverFloat obs)
    {
        if (!_allObservers.Contains(obs))
            _allObservers.Remove(obs);
    }

    public void NotifyToObserver(float life)
    {
        for (int i = 0; i < _allObservers.Count; i++)
        {
            _allObservers[i].notify(life);
        }
    }

}
