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
        exit
    }

    Phase _phase = Phase.enter;

    float timer = 0;
    float _frequency;

    float _time_phase_1 = 1;
    float _time_phase_2 = 3;
    public Enemy_SegmentedMovement(Transform transform, Vector3 dir, ShootMethod shoot, float startSpeed = 2, float exitSpeed = 1, float frequency = 1)
    {
        _transform = transform;
        _startSpeed = startSpeed;
        _exitSpeed = exitSpeed;
        _dir = dir;
        _shoot = shoot;
        _frequency = frequency;
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

            case Phase.exit:
                Phase3();
                return;
        }
    }

    void Phase1()
    {
        _transform.position += _dir * _startSpeed * Time.deltaTime;
        timer += Time.deltaTime;
        if (timer > _time_phase_1)
            _phase = Phase.stop;
    }

    void Phase2()
    {
        timer += Time.deltaTime;

        if (timer % _frequency == 0)
            _shoot(_type);

        if (timer > _time_phase_2)
            _phase = Phase.exit;
    }

    void Phase3()
    {
        _transform.position += _dir * _exitSpeed * Time.deltaTime;
    }
}
