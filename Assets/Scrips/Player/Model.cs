using System;
using System.Collections.Generic;
using UnityEngine;

public class Model : Ilife, IObservableFloat
{
    int _life;
    Transform _transform;
    public event Action hit;
    public event Action dead;
    public event Action move;
    public event Action stop;
    List<IObserverFloat> _allObservers = new List<IObserverFloat>();
    bool invensivility;
    float timer;


    public Model(int life ,Transform transform, List<IObserverFloat> allObservers)
    {
        _life = life;
        _transform = transform;
        _allObservers = allObservers;

    }



    public void Move(float h, float v)
    {
         
        var dir = _transform.up * v;
        dir += _transform.right * h;
        dir.z = 0;

        if (dir.magnitude > 0)
            move?.Invoke();
        else
            stop?.Invoke();

        _transform.position = pos(_transform.position) + dir * FlyweightPointer.Player.speed * Time.deltaTime;

        if (invensivility)
        {
            timer += Time.deltaTime;
            if (timer >= FlyweightPointer.Player.IFrames)
            {
                invensivility = false;
                timer = 0;
            }

        }

    }

    public Vector3 pos(Vector3 ae)
    {
        if (ae.x >= BorderManager.Instance.MaxX()) ae = new Vector3(BorderManager.Instance.MaxX(), ae.y, ae.z);
        if (ae.x <= BorderManager.Instance.MinX()) ae = new Vector3(BorderManager.Instance.MinX(), ae.y, ae.z);
        if (ae.y >= BorderManager.Instance.MaxY()) ae = new Vector3(ae.x, BorderManager.Instance.MaxY(), ae.z);
        if (ae.y <= BorderManager.Instance.MinY()) ae = new Vector3(ae.x, BorderManager.Instance.MinY(), ae.z);
        return ae;
    }


    public void Damage(int dmg)
    {
        if (invensivility)
            return;
        _life -= dmg;
        invensivility = true;

        Debug.Log("current life " + _life);
        hit?.Invoke();
        NotifyToObserver(_life);
        if (_life <= 0)
            Dead();
    }
    

    public void Dead()
    {
        dead?.Invoke();
        GameMenuManager.instance.Dead();
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
