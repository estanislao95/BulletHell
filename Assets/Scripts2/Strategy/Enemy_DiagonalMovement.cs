using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_DiagonalMovement : Abstract_SegmentedMovement
{
    Transform _transform;
    Vector2 _speed;

    float _frequency;

    float dir = 1;

    enum Phase
    {
        move,
        shoot
    }

    Phase _phase = Phase.move;

    float[] _time_phase = { 2, 1,};

    float shootTime = 0;
    public Enemy_DiagonalMovement(Transform transform, ShootMethod shoot, Vector2 speed, float frequency = 0.5f)
    {
        _transform = transform;
        _speed = speed;
        _shoot = shoot;
        _frequency = frequency;
        _time_phase = CalculateTime(_time_phase);
    }

    public void SetPhases(float[] phases)
    {
        _time_phase = CalculateTime(phases);
    }

    public override void Move()
    {
        switch (_phase)
        {
            case Phase.move:
                Phase1();
                return;

            case Phase.shoot:
                Phase2();
                return;
        }
    }
    public void Phase1()
    {
        _transform.position += -_transform.up * _speed.y * Time.deltaTime;

        _transform.position += _transform.right * dir * _speed.x * Time.deltaTime;

        timer += Time.deltaTime;

        if (_anim != null)
            _anim.Move();



        if (timer > _time_phase[((int)_phase)])
        {
            _phase = Phase.shoot;

            dir = -dir;
        }
    }

    public void Phase2()
    {
        timer += Time.deltaTime;
        shootTime += Time.deltaTime;

        if (_anim != null)
            _anim.Stop();

        if (shootTime > _frequency)
        {
            shootTime = 0;
            _shoot(_type);

            if (_anim != null)
                _anim.Shoot();
        }

        if (timer > _time_phase[((int)_phase)])
        {
            _phase = Phase.move;
            shootTime = 0;
            timer = 0;

        }
    }
}
