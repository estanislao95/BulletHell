using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SegmentedMovement : Enemy_Movement
{
    Transform _transform;
    float _startSpeed;
    float _exitSpeed;
    Vector3 _dir;


    enum Phase
    {
        enter,
        stop,
        wait,
        escape

    }

    Phase _phase = Phase.enter;

    float timer = 0;
    float shootTimer = 0;
    float _frequency;

    float[] _time_phase = { 2, 3, 1};
    
    public Enemy_SegmentedMovement(Transform transform, Vector3 dir, ShootMethod shoot, float startSpeed = 2, float exitSpeed = 1, float frequency = 1)
    {
        _transform = transform;
        _startSpeed = startSpeed;
        _exitSpeed = exitSpeed;
        _dir = dir;
        _shoot = shoot;
        _frequency = frequency;

        float sum = 0;
        for (int i = 0; i < _time_phase.Length; i++)
        {
            _time_phase[i] += sum;
            sum += _time_phase[i];
        }
    }

    

    public override void Move()
    {
        switch (_phase)
        {
            case Phase.enter:
                Phase1();
                return;

            case Phase.stop:
                Phase2();
                return;

            case Phase.wait:
                Phase3();
                return;

            case Phase.escape:
                Phase4();
                return;
        }
    }

    void Phase1()
    {
        _transform.position += _dir * _startSpeed * Time.deltaTime;
        timer += Time.deltaTime;

        if (_anim != null)
            _anim.Move();

        if (timer > _time_phase[0])
        {
            shootTimer = 0;
            _phase = Phase.stop;
        }

    }

    void Phase2()
    {
        timer += Time.deltaTime;
        shootTimer += Time.deltaTime;

        if (_anim != null)
            _anim.Stop();

        if (shootTimer >= _frequency)
        {
            _anim.Shoot();
            _shoot(_type);
            shootTimer = 0;
        }

        if (timer > _time_phase[1])
        {
            _phase = Phase.wait;
            shootTimer = 0;
        }
            

    }

    void Phase3()
    {
        timer += Time.deltaTime;

        if (_anim != null)
            _anim.Move();

        if (timer > _time_phase[2])
        {
            _phase = Phase.escape;
        }
    }

    void Phase4()
    {
        _transform.position += _dir * _exitSpeed * Time.deltaTime;
    }

    public override void SetTimer(float t)
    {
        timer = t;
    }

    public override  float GetTimer()
    {
        return timer;
    }
}
