using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMovement : IMovement
{
    Transform _transform;
    float _vspeed;
    float _hspeed;
    float _frecuency;
    Vector3 _forwarddir;
    Vector3 _sidewaysdir;
    float timer = 0;
    float sideSway = 0;
    public SineMovement(Transform transform, Vector3 forwarddir, Vector3 sidewaysdir, float vspeed = 1, float hspeed = 3, float frecuency = 0.25f)
    {
        _transform = transform;
        _hspeed = hspeed;
        _vspeed = vspeed;
        _frecuency = frecuency;
        _forwarddir = forwarddir;
        _sidewaysdir = sidewaysdir;

        timer = frecuency / 2;
    }
    public void Move()
    {
        timer += Time.deltaTime;
        if (timer >= 0 && timer < _frecuency)
        {
            sideSway = 1;
        }
        else if (timer >= _frecuency && timer < (_frecuency*2))
        {
            sideSway = -1;
        }
        else
        {
            timer = 0;
        }
        _transform.position += (_forwarddir * _vspeed) * Time.deltaTime + (_sidewaysdir * (sideSway) * _hspeed) * Time.deltaTime;

        Debug.Log(timer);
    }
}
